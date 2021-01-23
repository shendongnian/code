    public class person 
    {
        public int id{get; set;}
        public string name{get; set;}
        public int age{get; set;}
        public List<Salary> Salaeries {get; set;}
    }
    public class Salary
    {
        int month{get; set;}
        int money{get; set;}
    }
