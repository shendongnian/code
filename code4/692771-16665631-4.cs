    public class HelpWith
    {
        public int UserId { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Subcategories { get; set; }
        //constructor
        public HelpWith()
        {
            Categories = new List<int>();
            Subcategories = new List<int>();
        }
    }
