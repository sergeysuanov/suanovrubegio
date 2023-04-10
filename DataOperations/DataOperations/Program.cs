using DataOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataHandler = new DataHandler();


            var session1 = new Session
            {
                Id = 1,
                Name = "Сесcия 1",
                Description = "Описание сессии 1"
            };

            dataHandler.Create(session1);


            var readSession = dataHandler.Read(1);
            Console.WriteLine("Имя сессии: " + readSession.Name);
            Console.WriteLine("Описание сессии: " + readSession.Description);


            readSession.Name = "Новое имя";
            readSession.Description = "Новое описание";
            dataHandler.Update(readSession);


            dataHandler.Delete(1);

            Console.ReadLine();
        }
    }
    class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    class DataHandler
    {



        private List<Session> sessions = new List<Session>();

        public void Create(Session session)
        {
            sessions.Add(session);
        }

        public Session Read(int id)
        {
            return sessions.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Session session)
        {
            var existingSession = sessions.FirstOrDefault(s => s.Id == session.Id);
            if (existingSession != null)
            {
                existingSession.Name = session.Name;
                existingSession.Description = session.Description;
            }
        }

        public void Delete(int id)
        {
            var sessionToDelete = sessions.FirstOrDefault(s => s.Id == id);
            if (sessionToDelete != null)
            {
                sessions.Remove(sessionToDelete);
            }
        }
    }
}