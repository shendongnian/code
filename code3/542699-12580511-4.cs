    public class Employee
    {
        public string empName { get; set; }
        public string empID { get; set; }
        public string empLoc { get; set; }
        public string empPL { get; set; }
        public string empShift { get; set; }
        public class Comparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee x, Employee y)
            {
                return x.empLoc == y.empLoc
                    && x.empPL == y.empPL
                    && x.empShift == y.empShift;
            }
            public int GetHashCode(Employee obj)
            {
                unchecked  // overflow is fine
                {
                    int hash = 17;
                    hash = hash * 23 + (obj.empLoc ?? "").GetHashCode();
                    hash = hash * 23 + (obj.empPL ?? "").GetHashCode();
                    hash = hash * 23 + (obj.empShift ?? "").GetHashCode();
                    return hash;
                }
            }
        }
    }
