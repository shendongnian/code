    public class Category {
      public long CategoryId { get; set; }
      public string CategoryName { get; set; }
    } 
...
    public class CategoryEqualityComparer : IEqualityComparer<Category>
    {
       public bool Equals(Category x, Category y)
         => x.CategoryId.Equals(y.CategoryId)
              && x.CategoryName .Equals(y.CategoryName, 
     StringComparison.OrdinalIgnoreCase);
       public int GetHashCode(Mapping obj)
         => obj == null 
             ? 0
             : obj.CategoryId.GetHashCode()
               ^ obj.CategoryName.GetHashCode();
    }
