    public class SampleData
    {
        public SampleData(string name, string phoneNbr, string appStatus)
        {
            this.name = name;
            this.phoneNbr = phoneNbr;
            this.appstatus = appstatus;
        }
    
        public string name { get; private set; }
        public string phoneNbr { get; private set; }
    
        public string appstatus {  get; private set;  }
