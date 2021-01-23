            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Forename = "Onam", Surname = "Chilwan", DOB = new DateTime(1984, 8, 23) });
            persons.Add(new Person() { Forename = "Onam", Surname = "Chilwan", DOB = new DateTime(1972, 8, 23) });
            persons.Add(new Person() { Forename = "Onam", Surname = "Chilwan", DOB = new DateTime(1988, 8, 23) });
            persons.Add(new Person() { Forename = "Onam", Surname = "Chilwan", DOB = new DateTime(1984, 8, 23) });
            int[] years = persons.Select(x => x.DOB.Year).Distinct().ToArray();
        public class Person
        {
            public string Forename;
            public string Surname;
            public DateTime DOB;
        }
