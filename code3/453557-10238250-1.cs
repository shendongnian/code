    public class Category : IChildItem<Category>
    {
        private string _name;
        private readonly ChildItemCollection<Category, Category> _subCategories;
        private Category _parent;
        
        public Category()
        {
            _subCategories = new ChildItemCollection<Category, Category>(this);
        }
    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    
        public ChildItemCollection<Category, Category> SubCategories
        {
            get { return _subCategories; }
        }
    
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public Category Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
    }
