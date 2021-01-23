    public abstract class BaseClass
    {
      public BaseClass(){}
    
      public void Method(int val)
      {
          //base class logic here
          //now call DoSomething implementation
          DoSomething(val);
          //some other base class logic here
      }
    
      protected abstract void DoSomething(int val);
    }
    
    public class Derived : BaseClass
    {
        protected override void DoSomething(int val)
        {
           //other logic
        }
    }
