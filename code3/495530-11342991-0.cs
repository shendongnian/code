    public interface ISomething
    {
        void DoOne();
        void DoTwo();
    }
    public class Something : ISomething
    {
        public virtual void DoOne() { }
        public virtual void DoTwo() { }
    }
