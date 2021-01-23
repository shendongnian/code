    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public int svar_reserved_space { get; set; }
    }
    public class Parent
    {
        public Project Project { get; set; }
    }
