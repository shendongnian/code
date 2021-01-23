    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<String> Skills { get; set; }
        public Employee()
        {
            Skills=new List<string>();
        }
    }
