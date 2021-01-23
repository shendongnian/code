    public partial class Product
    {
      public string CategoryName
      {
        get {return this.Category.CategoryName;}
        set{this.Category.CategoryName = value;}
      }
    }
