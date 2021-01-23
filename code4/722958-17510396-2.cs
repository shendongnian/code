    public class Category
    {
         [Key]
         public int Id{get;set;}
    
         public string Name {get;set;}
    
         public ICollection<SubCategory> SubCategories{get;set;}
    }
    
    public class SubCategory
    {
         [Key]
         public int Id{get;set;}
    
         public string Name {get;set;}
    
         public int CategoryId {get;set;}
         
         [ForeignKey("CategoryId")]
         public Category Category {get;set;}
    }
