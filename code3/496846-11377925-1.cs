        using (var fdb = new FALDbContext()) 
    {     
        var members = fdb.Members.Where(m=>m.FirstName == "Bob");      
        foreach (var member in members)     
        {         
            fdb.Places.Where(p => p.PlaceName.StartsWith("B") && p.Member.Id == member.Id).Select(p => p.PlaceName);
            foreach (var place in places)         
            {             
                Console.WriteLine(place);         
            }     
        } 
    } 
