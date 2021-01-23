        struct Person
        {
            public string firstName;
            public string lastName;
            public int age;
         
            public Person(string _firstName, string _lastName, int _age)
            {
                firstName = _firstName;
                lastName = _lastName;
                age = _age;
            }
    
            public override string toString()
            {
                return firstName + " " + lastName + ", age " + age;
            }
        }
