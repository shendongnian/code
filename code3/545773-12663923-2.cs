       public class Category
       {
          public int ID { get; set; }
          
          public virtual Category RootCategory { get; set; }
          [ForeignKey("RootCategory")]
          public int? RootCategoryID { get; set; } // This does not set itself properly
    
          public virtual ICollection<Category> ChildCategories { get; set; }    
       }
