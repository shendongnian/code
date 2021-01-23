    public class Person 
    {
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string FullName
        {
            get
            {
                return item.fname + " " + item.mname[0] + " " + item.lname;
            }
        }
        public Person(string fname, string mname, string lname) 
        {
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
        }
    }
