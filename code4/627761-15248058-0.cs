        public class Post : Entity
        {
         public string Id { get; set; }
         public string Title { get; set; }
         public string Summary { get; set; }
         public DateTime Added { get; set; }
         public DBRef Owner { get; set; }
        }    
  
