    public Save() {
        using(DatabaseContect ct = new DatabaseContext())
        {
          ct.Persons.Attach(psn);
          ct.SaveChanges();
        }
    }
