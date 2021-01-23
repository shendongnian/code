    public class ProductVm
    {
        //some other properties        
    
        [DisplayName("Product Category", e => e.Description)]
        public Category Category {get; set;}
        [DisplayName("Parent Category", e => e.Description)]
        public Category ParentCategory {get; set;}
    }
