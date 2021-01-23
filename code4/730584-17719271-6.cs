    public abstract class Person
    {
        public virtual void ShowInfo()
        {
            Console.WriteLine("I am a person!");
        }
    }
    public class Teacher : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine("I am a teacher!");
        }
    }
