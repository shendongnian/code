    public class Y
    { }
    
    public class X : Y
    { }
    
    public class W : Y
    { }
    
    public interface IAaa<T>
        where T : Y
    {
        void Execute(T ppp);
    }
    
    public abstract class Aaa<T> : IAaa<T>
        where T : Y
    {
        public abstract void Execute(T ppp);
    }
    
    public class Bbb : Aaa<X>
    {
        public override void Execute(X ppp)
        { }
    }
    
    public class Ccc : Aaa<W>
    {
        public override void Execute(W ppp)
        { }
    }
    
    public class Factory<T> where T : Y
    {
        public static IAaa<T> Get(bool b)
        {
            if(b)
                return (IAaa<T>)new Bbb();
            else
                return (IAaa<T>)new Ccc();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IAaa<X> aa;
            aa = Factory<X>.Get(true);
        }
    }
