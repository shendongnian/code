    [ComplexType]
    public class MyComplexType {
        [Key]
        public int Id { get; set; }
        public string SomeString { get; set; }
        public IEnumerable<MySubType> SubTypes { get; set; }
    }
    
    [ComplexType]
    public class MySubType {
        [Key]
        public int Id { get; set; }
        public string AnotherString { get; set; }
    }
