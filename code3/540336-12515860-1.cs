    class Person
    {
        public Person(string fullName)
        {
            this.fullName = fullName;
        }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string initials;
        public string Initials
        {
            get { return String.Join("", fullName.Split(new char[] { ' ' }).Select(i => i.Substring(0, 1))); }
            set { initials = value; }
        }
    }
