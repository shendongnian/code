    [TestClassMeta]
    class TestClass { }
    class TestClassMetaAttribute : Attribute
    {
        [ViewModelPropertyName("TheName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
