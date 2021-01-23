    using (var context = new TestContext())
    {
        var person = context.Persons.Where(f => f.Id == 1).FirstOrDefault();
        var team = context.Teams.Where(f => f.Id == 3).FirstOrDefault();
        
        person.Teams.Add(team);
    
        context.Entry(person).State = EntityState.Modified;
        context.SaveChanges();
    }
