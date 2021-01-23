    public interface IBaseInterface
    {
    }
    
    public interface IInterface1 : IBaseInterface
    {
            //some code here.... 
    }
    
    public interface IInterface2
    {
            //some code here.... 
    }
    
    public class Class1
    {
        public void Test()
        {
            Activate<IInterface1>("myPath");
            //Activate<IInterface2>("myPath"); ==> doesn't compile
        }
    
        public static IT Activate<IT>(string path) where IT : IBaseInterface
        {
            //some code here.... 
        }
    }
