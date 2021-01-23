     using ( var t = new Tww.SV.Models.Model.Portal.SVPortalEntities() )
     {
           testaddress = ( from c in t.Adresses
                           select c ).ToList().FirstOrDefault();
           var newPerson = new Person();
           newPerson.Name = "Henry";
           newPerson.Adresses.Add( testaddress );
           k.Persons.Add(newPerson);
           k.SaveChanges();
     }
