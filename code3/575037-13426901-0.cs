    [DataContract]
    [KnownType(typeof(BaseClass))]
    public class DerivedClass : List<BaseClass>
    {
      /// ...
    }
    
    [DataContract]
    public clas BaseClass
    {
        //Add the DataMemberAttribute to the properties you want serialized.
    }
