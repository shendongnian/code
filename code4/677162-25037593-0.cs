    [DataContract]
    [KnownType("GetDerivedTypes")]
    public class BaseClass
    {
      public static List<Type> DerivedTypes = new List<Type>();
    
      private static IEnumerable<Type> GetDerivedTypes()
      {
        return DerivedTypes;
      }
    }
    
    
    [DataContract]
    public class DerivedClass : BaseClass
    {
      //static constructor
      static DerivedClass()
      {
        BaseClass.DerivedTypes.Add(typeof(DerivedClass)); 
      }
    }
