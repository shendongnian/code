    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // public API method
    public PersonDto GetPersonApi(int id)
    {
        var personEntity = // pull entity from db
        return new PersonDto()
        {
            FirstName = personEntity.FirstName,
            LastName = personEntity.LastName
        };
    }
