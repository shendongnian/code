    public class Category 
    {
      public int Id;
      public string Name;
      Dictionary<int, string> Subcategories = new Dictionary<int, string>();
    }
    Dictionary<int, Category> Categories;
