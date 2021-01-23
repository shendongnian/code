    public class MyClass
    {
       public Boolean success { get; set; }
       public String msg { get; set; }
       public override string ToString()
       {
         // return Whatever formalism of strings, e.g.
         return success? "Yeah":"Sorry" + msg;
       }
    }
