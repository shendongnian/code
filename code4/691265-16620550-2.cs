    class Details
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
          get { return string.Concat(this.FirstName, " ", this.LastName); }
        }
    }
