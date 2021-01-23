    public class DocumentWithUserCount  //:Document
    {
        public Doucument { get; set; }
        public int Amount {get;set}
    }
    var eds = from d in _entity.Document       
       select new DocumentWithUserCount { Document=d, Amount=d.Users.Count() };
