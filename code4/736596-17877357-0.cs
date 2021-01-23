      public class Category
    {
    
       public string Value{ get; set; }
    
     }
     var categories = JsonConvert.DeserializeObject<List<Category>>(json)
