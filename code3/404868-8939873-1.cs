    // your primary tree
    public class CategoryTree : IHierarchicalEnumerable {
        // Field to keep the collection data
        private IEnumerable<Category> Categories;
        // Empty constructor
        public CategoryTree() {
            //Init an empty list to avoid NullReferenceException
            Categories = new List<Category>();
        }
        // Primary constructor of our interest
        public CategoryTree(IEnumerable<Category> categories) {
            // Assign the collection data to the internal list
            Categories = categories;
        }
        public IHierarchyData GetHierarchyData(object enumeratedItem) {
            //cast the object
            var cat = enumeratedItem as Category;
            //create a new hierarchy item
            return new CategoryHierarchyItem(cat);
        }
        public System.Collections.IEnumerator GetEnumerator() {
            //IEnumerable support for foreach loop
            return Categories.GetEnumerator();
        }
    }
