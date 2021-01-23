    public static IEnumerable GetPersons()
    {
       using(StaffEntities context = new StaffEntities())
       {
            return from person in context.Persons.ToList()
                   select new Person()
                   {
                       Firstname = person.Firstname
                   }
       }
    }
