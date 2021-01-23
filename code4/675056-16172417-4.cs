    public abstract class Animal<T> where T: Animal<T>
    {
        public abstract Animal<T> GiveBirth();
    }
    public class Monkey: Animal<Monkey>
    {
        public override Animal<Monkey> GiveBirth()
        {
            return new Monkey();
        }
    }
    public class Snake: Animal<Snake>
    {
        public override Animal<Snake> GiveBirth()
        {
            return new Snake();
        }
    }
    public class WeirdHuman: Animal<WeirdHuman>
    {
        public override Animal<WeirdHuman> GiveBirth()
        {
            return new Monkey(); // Won't compile of course.
        }
    }
