    class A : I
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public A(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }
    class B : I
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public B(string name, int age, string location)
        {
            Name = name;
            Age = age;
            Location = location;
        }
    }
