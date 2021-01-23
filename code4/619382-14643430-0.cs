     public ActionResult Index()
            {
             //   MongoDatabase databse = MongoDatabase.Create("mongodb://localhost:27017/BeniSoftLabs");
                MongoDatabase mongodb = DBConn.DBConn.getDBConn();
                var menu = mongodb.GetCollection<Menu>("Menu").FindOne();
                
                
       }
     public class Node
        {
            public virtual string NodeTitle { get; set; }
            public virtual string Link { get; set; }
            public virtual string IconName { get; set; }
            public virtual string ClassName { get; set; }
            public virtual IList<Node> NodeList { get; set; }
    
        }
     public class Menu
        {
            public virtual ObjectId id { get; set; }
            public virtual IList<Node> MenuList { get; set; }
            public virtual IList<Node> RightMenuList { get; set; }
        }
