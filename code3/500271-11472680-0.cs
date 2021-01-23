    public class CustomerView
    {
        public long id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String streetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zip { get; set; }
        public String profession { get; set; }
        public virtual String[] linesOfBusiness { get; set; }
    }
