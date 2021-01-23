    public class Base
    {
       public Base(string theString) { ... }
    }
    
    public class Derived:Base
    {
       public Derived():base("defaultValue") //perfectly valid
       { ... }
       public Derived(string theString)
          :base(theString)
       { ... }
       public Derived(string theString, Other otherInstance)
          :base(theString) //also perfectly valid
       { ... }
    }
