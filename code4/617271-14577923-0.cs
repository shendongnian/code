    [XmlRoot("categories")]
    public class Categories
    {
        public Categories() 
        {
           Items = new List<User>();
        }
        [XmlElement("category")]
        public List<Category> Items {get;set;}
    }
