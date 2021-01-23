    class MyItem
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MyItem> myItems = new List<MyItem>()
            {
                new MyItem() { Location = "011", Name = "pen" },
                new MyItem() { Location = "011", Name = "paper" },
                new MyItem() { Location = "012", Name = "tv remote" }
            };
            var specificItems = myItems.Where(f => f.Location == "011");
            foreach (var item in specificItems)
            {
                Console.WriteLine(item.Name);
            }
            Console.Read();
        }
    }
