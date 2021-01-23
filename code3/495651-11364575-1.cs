    using System.ComponentModel.DataAnnotations;
    [ComplexType]
    public class MyComplexType {
        public int Id { get; set; }
        public string SomeString { get; set; }
        public IEnumerable<MySubType> SubTypes { get; set; }
    }
    
    [ComplexType]
    public class MySubType {
        public int Id { get; set; }
        public string AnotherString { get; set; }
    }
