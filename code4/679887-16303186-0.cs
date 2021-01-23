    class Employee2
    {
        private string name = "Harry Potter";
        private double salary = 100.0;
    
        protected string GetName()
        {
            return name;
        }
    
        protected string SetName(string newName)
        {
            this.name = newName;
        }
    
        protected double Salary
        {
            get { return salary; }
    
        }
    }
