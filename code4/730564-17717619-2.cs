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
