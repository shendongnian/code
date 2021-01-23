    class Mapper {
        public PersonDTO MapPerson(tPerson person) 
        {
            return new PersonDTO {
                 ID = person.ID,
                 Name = person.Name
            };
        }
    }
