    interface IEntity
    {            
        int Id { get; set; }            
        string TableName { get; }
        //etc
    }
    interface IPerson: IEntity
    {
        void Save();
    }
    interface IDatabase
    {
        void Save(IEntity entity);
    }
    class SQLDatabase : IDatabase
    {
        public void Save(IEntity entity)
        {
            //Your sql execution (very simplified)
            //yada yada INSERT INTO entity.TableName VALUES (entity.Id)
            //If you use EntityFramework it will be even easier
        }
    }
    class MockDatabase : IDatabase
    {
        public void Save(IEntity entity)
        {
            return;
        }
    }
    class Person : IPerson
    {
        IDatabase _database;
        public Person(IDatabase database)
        {
            this._database = database;
        }
        public void Save()
        {
            _database.Save(this);
        }
        public int Id
        {
            get;
            set;
        }
        public string TableName
        {
            get { return "Person"; }
        }
    }
