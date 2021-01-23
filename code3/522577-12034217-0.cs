    var person1 = new Person { ReferenceString = 12 };
                var person2 = new Person { ReferenceString = 11 };
                var person3 = new Person { ReferenceString = 14 };
    
                var people = new List<Person>();
                people.Add(person1);
                people.Add(person3);
                people.Add(person2);
    
                var returnValues = people.Where(x => x.ReferenceString == people.Min(y => y.ReferenceString));
