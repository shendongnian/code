    abstract class PropertyComparer<T> : Comparer<T>
    {
        protected string property;
        
        public PropertyComparer(string Property)
        {
            this.property = Property;
        }
    }
    
    class EmployeeComparer : PropertyComparer<Employee>
    {
        public EmployeeComparer(string Property) : base(Property)
        {
            
        }
        
        public override int Compare(Employee x, Employee y)
        ...
    }
