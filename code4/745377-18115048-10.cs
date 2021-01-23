    [MetadataType(typeof(TestClassMeta))]
    class TestClass { }
    class TestClassMeta
    {
        [ViewModelPropertyName("TheName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
