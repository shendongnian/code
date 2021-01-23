        struct Person
        {
             private readonly string firstName;
             private readonly string lastName;
             public Person(string firstName, string lastName)
             {
                 this.firstName = firstName;
                 this.lastName = lastName;
             }
             public string FirstName { get { return this.firstName; } }
             public string LastName { get { return this.lastName; } }
        }
