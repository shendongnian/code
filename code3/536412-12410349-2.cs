    public class YourModel
    {
        public YourModel(Category c, int count)
        {
            C = c;
            Count = count;
            c.Threads.Count = count;
        }
    
        public Category C { get; set; }
        public int Count { get; set; }
    }
    var model = forumsDb.Categories
        .Select(c => new YourModel(c, c.Threads.Count))
        .ToList()
