    public abstract class Employee
    {
        public abstract double Earnings { get; }
        public string Name { get; set; }
        public double Sin { get; set; }
        //public string Earnings { get; }
        public Employee(string name, double sin, double earnings)
        {
            Name = name;
            Sin = sin;
            Earnings = earnings;
        }
        
    }
}
