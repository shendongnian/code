    public class employee
    {
        public int employeeId{ get; set; }
        public string name{ get; set; }
        public ICollection<department> departments { get;set; }
    }
    public class deparment
    {
        public int deparmetId{ get; set; }
        public string Name { get; set; }
        public ICollection<employee> employees { get;set; }
        public ICollection<employee> bosses { get;set; }
    }
