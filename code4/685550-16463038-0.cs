    static void Main(string[] args)
        {
            var gateway = new Gateway();
            Console.WriteLine(gateway.DoSomethingWithPerson(new Staff(1)));
            Console.WriteLine(gateway.DoSomethingWithPerson(new Student(1)));
        }
        public class Staff : Person
        {
            public Staff() { }
            public Staff(int id) : base(id) { }
            public override void Update(object o)
            {
                Console.WriteLine(ID + " notified that {1}", ID, o);
            }
            public override void UpdateMessage(object p)
            {
                Console.WriteLine(ID + " notified about new message in chat: {1}", ID, p);
            }
            public override string GetName()
            {
                return DataBase.GetName(ID);
            }
        }
        public class Student : Person
        {
            public Student() { }
            public Student(int id) : base(id) { }
            public override void Update(object o)
            {
                Console.WriteLine(ID + "  notified that {1}", ID, o);
            }
            public override void UpdateMessage(object p)
            {
                Console.WriteLine("Message for " + ID + "  {1}", ID, p);
            }
            public override string GetName()
            {
                return "Go Away!";
            }
        }
        public abstract class Person : IPerson
        {
            public int ID;
            protected Person() { DataBase = new DataBase(); }
            public abstract string GetName();
            protected Person(int i) { ID = i; DataBase = new DataBase(); }
            public abstract void Update(Object o);
            public abstract void UpdateMessage(Object p);
            public DataBase DataBase { get; set; }
        }
        public interface IPerson
        {
            void Update(Object o);
            void UpdateMessage(Object p);
            string GetName();
        }
        public class DataBase
        {
            public string USERNAME = "username";
            private const string Name = "user details";
            private const string Grade = "user grade";
            public string GetName(int id)
            {
                // you should perform get something.
                return Name;
            }
            public string GetGrade() { return Grade; }
        }
        //maybe call it facade
        public class Gateway
        {
            public string DoSomethingWithPerson(IPerson person)
            {
                return person.GetName();
            }
        }
