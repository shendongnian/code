    public void AddCostumer(string name) 
    { 
        Costumers.InsertOnSubmit(new Costumers() { Name = name}); 
    
        // Submit the change to the database.
        try
        {
            db.SubmitChanges();
        }
        catch (Exception e)
        {
           // message to the user???
        }
    } 
