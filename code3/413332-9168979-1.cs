    public class FurtherDerived:Derived
    {
       public FurtherDerived(string theString, Other otherInstance)
          :base(theString, otherInstance)
       { ... }
       public FurtherDerived()
          :this("defaultValue", new Other()) //invokes the above constructor
       { ... }
    }
