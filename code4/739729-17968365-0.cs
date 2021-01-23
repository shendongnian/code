    public class Item
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
    public void DoWork()
        {
            Item[] data = new Item[] {
                new Item() { ID = 2, ParentID = 1, Name = "Test 2", SortOrder = 1},
                new Item() { ID = 3, ParentID = 1, Name = "Test 3", SortOrder = 2},
                new Item() { ID = 4, ParentID = 2, Name = "Test 4", SortOrder = 1},
                new Item() { ID = 1, ParentID = null, Name = "Test 1", SortOrder = 1},
            };
            var result = from x in data
                         orderby x.SortOrder, x.ParentID
                         select x;
            foreach (var row in result.ToArray())
            {
                Console.WriteLine(row.Name);
            }
        }
