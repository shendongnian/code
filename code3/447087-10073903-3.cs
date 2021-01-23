    class EmployeeComparer : Comparer<Employee>
    {
        string property;
        
        public EmployeeComparer(string Property)
        {
            this.property = Property;
        }
        
        public override int Compare(Employee x, Employee y)
        {
            switch (this.property)
            {
                case "Name":
                    return Comparer<string>.Default.Compare(x.Name, y.Name);
                case "Age":
                    return Comparer<int>.Default.Compare(x.Age, y.Age);
                default:
                    return 0;
            }
        }
    }
