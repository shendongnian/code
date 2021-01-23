    public class Program
    {
        private static void Main(string[] args)
        {
            Person teacher = new Teacher();
            teacher.ShowInfo();
            Person incognito = new IncognitoPerson ();
            incognito.ShowInfo();
            Console.ReadLine();
        }
    }
    
    public class Person
    {
        public virtual void ShowInfo()
        {
            Console.WriteLine("I am Person");
        }
    }
    
    public class Teacher : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine("I am Teacher");
        }
    }
    public class IncognitoPerson : Person
    {
    }
