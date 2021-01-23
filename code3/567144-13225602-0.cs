    DBLocalEntities client = new DBLocalEntities(URI);
    User newUser = new User()
        {
            //Set values to properties
        }
    client.AddTousers(newUser);
    client.SaveChanges();
