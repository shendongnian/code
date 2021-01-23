    public void Initialize()
    {
       using ( var db = new SQLite.SQLiteConnection( _dbPath ) )
       {
          db.CreateTable<Customer>();
     
          //Note: This is a simplistic initialization scenario
          if ( db.ExecuteScalar<int>( 
                 "select count(1) from Customer" ) == 0 )
          {
     
             db.RunInTransaction( () =>
             {
                db.Insert( new Customer() { 
                   FirstName = "Jon", LastName = "Galloway" } );
                db.Insert( new Customer() { 
                   FirstName = "Jesse", LastName = "Liberty" } );
             } );
          }
          else
          {
             Load();
          }
       }
    }
