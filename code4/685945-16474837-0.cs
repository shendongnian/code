    interface IEmployee : IComparable
    {
        String Name { get; set; }
        DateTime DOB { get; set; }
    }
    class Employee : IEmployee
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int CompareTo(object obj)
        {
            // code to compare this employee to (IEmployee) obj
            // ...
            throw new NotImplementedException();
        }
    }
