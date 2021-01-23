    public class PersonNew : Person
    {
        public static PersonNew CreateFromPerson(Person person, DateTime currentDateTime)
        {
            var newPerson = Mapper.Map<PersonNew>(person);
            newPerson.CurrentDateTime = currentDateTime;
        }
    }
