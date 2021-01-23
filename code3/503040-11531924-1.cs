    public class Foo
    {
       public Foo Rotate(int angle)
       {
           var newInstance = (Foo)this.MemberwiseClone();
           // do other stuff...
           return newInstance; 
       }
    }
