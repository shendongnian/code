    public class Derived1 : Base {
       public virtual void Connect()
       {
          DoConnect();
       }
    
       protected void DoConnect()
       {
          base.Connect();
       }
    }
