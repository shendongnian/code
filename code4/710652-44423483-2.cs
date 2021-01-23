    public class ProductVm
    {
        //some other properties        
    
        public Category Category {get; set;}
        public Category ParentCategory {get; set;}
        [DisplayName("Product Category")]
        public string Category => Category.Description;
        [DisplayName("Main Category")]
        public string ParentCategory => ParentCategory.Description;
    }
