        public class Category : Node
        {
            public Category()
            {
                // best practice so that nobody has to null check the collection
                ChildrenNodes = new List<Category>();
            }
            public virtual IList<Category> ChildrenNodes { get; private set; }
            public void Add(Category subcategory)
            {
                subcategory.Parent = this;
                ChildrenNodes.Add(subcategory);
            }
        }
        // in testcode
        categoryMenu.Add(new Category { Title = "SubService-Level1" });
