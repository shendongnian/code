    // Your primary class
    public class Category {
        public Int32 CategoryId { get; set; }
        public Int32? ParentCategoryId { get; set; }
        public String CategoryName { get; set; }
        // List of children if any.
        // In this example if your category doesn't have any children
        // it is supposed to be null
        public List<Category> Children { get; set; }
        // The parent category. If this is your topmost category 
        // this property is deemed to be null.
        public Category Parent { get; set; }
        public override String ToString() {
            return this.CategoryName;
        }
    }
