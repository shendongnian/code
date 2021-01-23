    [Serializable]
    public class A
    {
        public int SimpleSerialisableProperty { get; set;}
    }
    
    public class B : A
    {
        public C ComplexReferenceProperty { get; set; }
    }
    [Serializable]
    public class D : A
    {
        public bool AnotherSerialisableProperty { get; set;}
    }
    
