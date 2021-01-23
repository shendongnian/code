    public class Parent
    {
        public virtual string SayHi()
        {
            return "Hi!";
        }
    }
    public class NiceChild : Parent
    {
        public override string SayHi()
        {
            return "Hello World!";
        }
    }
    public class MeanChild : Parent
    {
        public override string SayHi()
        { 
            return "You suck!";
        }
    }
