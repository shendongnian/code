      public class SimpleClass
    {
        public int IdSimpleClass { get; set; }
        public string NameSimpleClass { get; set; }
    }
    public class NestingClass
    {
        public string Address { get; set; }
        public List<SimpleClass> SimpleClass { get; set; }
    }
    public class SuperNestingClass
    {
        public string SomeId { get; set; }
        public string AnotherId { get; set; }
        public Guid Guid { get; set; }
        public List<NestingClass> NestingClass { get; set; }
    }
