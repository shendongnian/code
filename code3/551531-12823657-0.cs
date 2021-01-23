    [DataContract]
    [KnownType(typeof(B))]
    [KnownType(typeof(C))]
    public class A
    {
        [DataMember] 
        private SuperClass myProp;
    }
    public Class B : SuperClass  {}
    public Class C : SuperClass  {}
