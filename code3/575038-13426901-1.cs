    [DataContract]    
    public class DerivedClass : List<BaseClass>
    {
      /// ...
    }
    
    [DataContract]
    [KnownType(typeof(DerivedClass))]
    public clas BaseClass
    {
        //Add the DataMemberAttribute to the properties you want serialized.
    }
