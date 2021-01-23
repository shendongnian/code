     public class Category
    {
       [Key]
       public long Id { get; private set; }
       public string CategoryName { get; private set; }
       public long? ParentCategoryId { get; private set; }
       public Category ParentCategory { get; private set; }       
       public ICollection<Category> SubCategories { get; private set; }
    }
