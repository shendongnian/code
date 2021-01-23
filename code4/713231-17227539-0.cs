    public class BaseClass
    {
       public virtual void MyFunction()
       {
          Console.WriteLine("");
       }
    }
    
    
    public override class DerivedClass:BaseClass
    {
        public void MyFunction()
        {
            Console.WriteLine("");
        }
    }
