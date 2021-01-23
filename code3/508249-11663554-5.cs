    using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
    {
        // SqlFunctions.CharIndex is executed in the database.
        var contacts = from c in AWEntities.Contacts
                       where SqlFunctions.CharIndex("Si", c.LastName) == 1
                       select c;
    
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact.LastName);
        }
    }
