    using System.Data.Entity.Migrations;
    
    public void Save(Person person) {
        var db = new MyDbContext();
        db.People.AddOrUpdate(person);
        db.SaveChanges();
    }
