    public class Project
    {
        public DateTime LastModified;
        public string LoanName;
        public string LoanNumber;
        public int LoanProgram;
        public string ProjectAddress;
        ...
    
        // Project class constructor
        public Project(Dictionary<string, object> Dict)
        {
            foreach (KeyValuePair<string, object> entry in Dict)
            {
               this.GetType().GetProperty(entry.Key).SetValue(this, entr.Value, null);
            }
        }
    }
