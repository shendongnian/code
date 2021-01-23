        class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class SubItem
    {
        public int Id { get; set; }
        public int ForeignKey { get; set; }
        public string SubName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sub = new List<SubItem>();
            var item = new List<Item>();
            
            sub.Where(s => item.Select(i => i.Id).Contains(s.ForeignKey)).ToList();
        }
    }
