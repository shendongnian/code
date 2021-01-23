      class Employee
    {
        public string firstName { get; set; }
        public string middleName { get; set;}
        public string lastName { get; set; }
        public string fullName { get; set; }
        //add other attributes here just the same...
        public Employee(string first, string middle, string last, string full)
        {
            firstName = first;
            middleName = middle;
            lastName = last;
            fullName = full;
            //assign ther other attributes..
        }
    }
