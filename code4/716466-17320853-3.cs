    public class Employee
    {
        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;
            if (other == null)
                return false;
            return this.Id == other.Id; // for example
        }
    }
