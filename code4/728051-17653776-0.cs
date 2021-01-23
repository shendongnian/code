    private void UpdatePerson(PersonViewModel v)
    {
        using (ProActiveDBEntities context = new ProActiveDBEntities())
        {
            var p = context.Users.Where(c => c.PersonID == v.PersonID).SingleOrDefault(); //retrieve the person by its PK ID
       
            if (p != null)
            {
               p.PersonID = v.PersonID; //Map the properties/Fields within your EF model to the ones in your view model
               p.Surname = v.Surname;
               //etc...
                
               context.SaveChanges();
            }
         }
    }
