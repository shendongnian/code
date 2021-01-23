    public class BaseClass {
       public virtual void Something() {
          Console.WriteLine("base functionality");
       }
    }
    
    public class Sub1 : BaseClass {
       public override void Something() {
           // do whatever you want here
           base.Something();  // don't call it at all if you like
           // do whatever you want here
       }
    }
