    public class Base {
       public virtual void Connect()
       {
          DoConnect();
       }
    
       protected void DoConnect()
       {
          // do stuff
       }
    }
    ...
    public class Derived2 : Derived1 {
       public override void Connect()
       {
          DoConnect();
          ...
       }
    }
