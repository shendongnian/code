    public class EmployeeComparer : IComparer<IEmployee>
    {
        public int Compare(IEmployee e1, IEmployee e2)
        {
            return e1.Name.CompareTo(e2.Name);
        }
    }
