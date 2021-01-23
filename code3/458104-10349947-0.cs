    public class Employee
    {
        public string FirstName;
        public string LastName;
        public string JobTitle;
    
        // all other declarations here
        ...........
    
        // Override ToString()
        public override string ToString()
        { 
             return string.Format("'{0}', '{1}', '{2}'", this.FirstName, this.LastName, this.JobTitle);
        }
    }
