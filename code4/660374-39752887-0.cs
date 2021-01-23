    class Poco 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ssn { get; set; }
    }
    
    db.DropTable<Poco>();
    db.TableExists<Poco>(); //= false
    
    db.CreateTable<Poco>(); 
    db.TableExists<Poco>(); //= true
    
    db.ColumnExists<Poco>(x => x.Ssn); //= true
    db.DropColumn<Poco>(x => x.Ssn);
    db.ColumnExists<Poco>(x => x.Ssn); //= false
