    class Name
    {
        public string Name
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
