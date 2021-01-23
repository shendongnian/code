    class Person
    {
        private String name;
        private String sex;
        public Person(String name, String sex)
        {
            this.name = name;
            this.sex = sex;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Sex
        {
            get { return sex; }
            set { sex = value; }
        }
    }
