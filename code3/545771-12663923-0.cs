       public class Category
       {
          public int ID { get; set; }
          
          public Category RootCategory { get; set; }
          [ForeignKey("RootCategory")]
          public int? RootCategoryID { get; set; } // This does not set itself properly
    
          public ICollection<Category> ChildCategories { get; set; }    
       }
