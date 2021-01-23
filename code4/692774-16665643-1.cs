    public class HelpWith
    {
        public int UserId { get; set; }
        public int[] Categories { get; set; }
        public int[] Subcategories { get; set; }
    
        HelpWith()
        {
            Categories = new int[5];
            Subcategories = new int[5];
        }
    }
