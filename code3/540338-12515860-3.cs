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
            get { return String.Join("",new string[]{
                String.Join("",fullName.Split(new char[] { ' ' }).Take(1).Select(i => i.Substring(0, 2))),
                String.Join("",fullName.Split(new char[] { ' ' }).Skip(1).Select(i => i.Substring(0, 1)))
            });
            set { initials = value; }
        }
    }
