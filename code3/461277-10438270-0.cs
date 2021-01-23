    public class Type1
    {
        public TypeAsd asd { get; set; }
        public TypeBe be { get; set; }
    }
    
    public class TypeAsd
    {
        public int id { get; set; }
        public TypeBe profile { get; set; }
        public string name { get; set; }
    }
    
    public class TypeBe
    {
        public string username { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public int age { get; set; }
    }
