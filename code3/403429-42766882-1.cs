    [MetadataType(typeof(Base.Metadata))]
    public class Base
    {    
        public string RequiredProperty { get; set; }
        public class Metadata
        {
            [Required]
            public string RequiredProperty { get; set; }
        }
    }
    [MetadataType(typeof(Derived.Metadata))]
    public class Derived : Base 
    {
        public new class Metadata
        {
        }
    }
