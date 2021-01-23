    [DataContract(Name = "TestClass")]
    public class TestClass
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Age")]
        public int Age { get; set; }
    }
