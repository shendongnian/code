    class Program
    {
        static void Main(string[] args)
        {
            DoSomething doSomething = new DoSomething();
            doSomething.CallMe<MyAction>();
        }
    }
    public class DoSomething
    {
        public void CallMe<T>() where T : IMyAction
        {
           IMyAction action =  (IMyAction)Activator.CreateInstance(typeof(T));
           var result = action.DoThis("value");            
        }
    }
    public interface IMyAction
    {
        byte[] DoThis(string text);
    }
    public class MyAction : IMyAction
    {
        public byte[] DoThis(string text)
        {
            byte[] ret = new byte[0]; //mock just to denote something is done and out comes a byte array
            return ret;
        }
    }
    
