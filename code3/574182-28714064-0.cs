    using (var context = new TestContext())
    {
        context.People.Attach(person);
        
        //i'm not sure if this foreach is necessary, you can try without it to see if it works
        foreach (var team in person.Teams)
        {
            context.Teams.Attach(team);
        }
        
        context.Entry(person).State = EntityState.Modified;
        
        context.SaveChanges();
    }
