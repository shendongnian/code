    public class ProductModel
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public CategoryPropertyModel Category { get; set; }
    }
    [MetadataType(typeof(ICategoryModelCategoryDisplay))
    public class CategoryModel : CategoryBaseModel { }
    [MetadataType(typeof(ICategoryModelDisplay))
    public class CategoryPropertyModel : CategoryBaseModel { }
    public class CategoryBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface ICategoryModelSimpleDisplay  
    {
        [DisplayName("Name")]
        public string Name { get; set; }
    }
    public interface ICategoryModelCategoryDisplay  
    {
        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
