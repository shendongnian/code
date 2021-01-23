    public class ClassA
    {
        public string id{ get; set; }
        public string name{ get; set; }
        public int status { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class ClassAList
    {
        public IList<ClassA> root_name{ get; set; } 
    }
