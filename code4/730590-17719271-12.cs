    public abstract class Person
    {
        public abstract void ShowInfo();
    }
    public class Teacher : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine("I am a teacher!");
        }
    }
    public class Student : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine("I am a student!");
        }
    }
