    public class SomeThing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string State { get; set; }
        public List<Goal> Goals { get; set; }
    }
    
    public class Goal
    {
        public int Id { get; set; }
        public string Description{ get; set; }
        public int DisplayOrder{ get; set; }
    }
