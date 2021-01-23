    using (PersonDataModelContainer dmc = new PersonDataModelContainer())
    {
        var pers = new Person() { Id = PersonId };
        var prof = new Profession() { Id = ProfessionId };
        pers.Professions.Add(prof);
        dmc.Persons.Add(pers);
        var result = dmc.SaveChanges();
    }
