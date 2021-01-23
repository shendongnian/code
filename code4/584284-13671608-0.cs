    public class Person
    {
        public string strFirstName;
        ...
    }
    public class Persons
    {
        List<Person> lstPersons = new List<Person>();
        public void AddPerson(string FirstName, ...)
        {
            Person person = new Person();
            person.strFirstName = FirstName;
            ...
            lstPersons.Add(person);
        }
    }
