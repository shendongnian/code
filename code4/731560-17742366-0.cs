        class Person {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public TimeSpan Age {
                get {
                    // calculate Age
                }
            }
        }
        var person = new Person {
                Name = "Mike",
                BirthDate = new DateTime(1990, 9, 2))
        };
