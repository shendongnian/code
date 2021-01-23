    public class Colour
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
    
    public class MyEntity
    {
        public string Name { get; set; }
        public Colour Colour { get; set; }
    }
    
    public class RootObject
    {
        public List<MyEntity> MyEntities { get; set; }
    }
