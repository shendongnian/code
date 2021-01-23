    public class Item
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        virtual public Category Category { get; set; }
        virtual public ICollection<Size> Sizes { get; set; }
        virtual public ICollection<Image> Images { get; set; }
    
        public Item()
        {
            Sizes = new List<Size>();
        }
    }
