    public static void InsertIntoDatabase(Person vPerson){
        using (var db = new DatabaseContext()) {
            var soundExQuery = db.People.Select(p => 
                  new { 
                          FirstNameSE = SqlFunctions.SoundCode(vPersion.FirstName), 
                          LastNameSE = SqlFunctions.SoundCode(vPersion.LastName) 
                }
            ).Take(1);
        
            var result = soundExQuery.ToArray();
        
            vPerson.FirstNameSE = result[0].FirstNameSE;
            vPersion.LastNameSE = result[0].LastNameSE;
            db.People.Add(vPerson);
            db.SaveChanges();
        }
    }
