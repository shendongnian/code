    public class BarClass {
        public String prop { get; set; }
    }
    public class FooClass {
        public List<BarClass> bar { get; set; } 
    }
    public class Model {
        public FooClass foo { get; set; }
    }
