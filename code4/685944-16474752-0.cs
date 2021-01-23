    public class EmployeeComparer : IComparer<IEmployee>
        {
            public int Compare(IEmployee x, IEmployee y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
