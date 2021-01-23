    public static class ConvertPersonToPersonModel
    {
        public static PersonModel ConvertToPersonModel(this Person person)
        {
            PersonModel p= new PersonModel(); //assign the properties
            p.Id = person.Id; 
            p.FirstName = person.FirstName; 
            return p;
        }
        public static IEnumerable<PersonModel> ConvertPeopleToPeopleModels(this List<Person> people)
        {
            List<PersonModel> ps= new List<PersonModel>();
            foreach (var person in people)
            {
                ps.Add(ConvertToPersonModel(person));
            }
            return ps.AsEnumerable<PersonModel>();
        }
    }
