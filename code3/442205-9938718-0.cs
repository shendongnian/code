    class Employee_Details : IEqualityComparer
    {
        public int Employee_ID;
        public Employee_Details(int empID)
        {
            Employee_ID = empID;
        }
    
        public new bool Equals(object x, object y)
        {
            return x.ToString().Equals(y.ToString());
        }
        public int GetHashCode(object obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    
        public override String ToString()
        {
            return Employee_ID.ToString();
        }
    }
