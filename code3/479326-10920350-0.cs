    public class MyObject {
        public int id {get;set;}
        public string Name {get;set;}
        public DateTime CreatedDate {get;set;}
    }
    public IQueryable<MyObject> GetAllPersons() 
    { 
        var Context = new DataModel.PrototypeDBEntities(); 
        var query = from p in Context.Persons 
                    select new MyObject
                    { 
                        id = p.PersonsId, 
                        Name = p.Name, 
                        CreatedDate = p.CreatedDate 
                    }; 
        return query;
    } 
