    public class BaseClass
    {
       public virtual void MyFunction()
       {
          Console.WriteLine("");
       }
    }
    
    
    public class DerivedClass:BaseClass
    {
        public overide void MyFunction()
        {
            Console.WriteLine("");
             if you want to call the base classes function also then call base.MyFunction() ; 
        }
    }
