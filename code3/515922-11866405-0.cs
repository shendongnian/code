    class Person {
        private string m_FirstName = string.Empty;
        private string m_LastName = string.Empty;
        public string FirstName {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }
        public string LastName {
            get { return m_LastName; }
            set { m_LastName = value;}
        }
        public string FullName {
             get { return m_FirstName + " " + m_LastName; }
        }
        public IEnumerable<Person> Children { get; set; }
    }
