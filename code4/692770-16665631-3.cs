    public class HelpWith
    {
        public int UserId { get; set; }
        public int[] Categories { get; set; }
        public int[] Subcategories { get; set; }
        //constructor
        public HelpWith()
        {
          this(10,10);
        }
        public HelpWith(int CategorySize, int SubCategorySize)
        {
         Categories = new int[CategorySize]; //some size
         SubCategories = new int[SubCategorySize];
        }
    }
