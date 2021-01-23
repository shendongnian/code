    public class Person
        {
            public bool UpdateFrom(Person otherPerson)
            {
                return Updater.Update(this, otherPerson);
            }
            [UpdateElement]
            public string Name { get; set; }
            [UpdateElement]
            public string LastName { get; set; }
        }
