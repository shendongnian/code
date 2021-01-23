    public class BaseClass
    {
       public virtual void MyFunction()
       {
          Console.WriteLine("");
       }
    }
    
    
    public class DerivedClass:BaseClass
    {
        public override void MyFunction()
        {
            Console.WriteLine("");
        }
    }
