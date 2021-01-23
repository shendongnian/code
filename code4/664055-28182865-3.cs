    class Program
    {
        static void Main(string[] args)
        {
            var flatItems = new List<Item>()
            {
                new Item(1),
                new Item(2),
                new Item(3, 1),
                new Item(4, 2),
                new Item(5, 4),
                new Item(6, 3),
                new Item(7, 5),
                new Item(8, 2),
                new Item(9, 3),
                new Item(10, 9),
            };
            var treeNodes = BuildTreeAndReturnRootNodes(flatItems);
            foreach (var n in treeNodes)
            {
                Console.WriteLine(n.Id + " number of children: " + n.Children.Count);
            }
        }
        // Here is the method
        static List<Item> BuildTreeAndReturnRootNodes(List<Item> flatItems)
        {
            var byIdLookup = flatItems.ToLookup(i => i.Id);
            foreach (var item in flatItems)
            {
                if (item.ParentId != null)
                {
                    var parent = byIdLookup[item.ParentId.Value].First();
                    parent.Children.Add(item);
                }
            }
            return flatItems.Where(i => i.ParentId == null).ToList();
        }
        class Item
        {
            public readonly int Id;
            public readonly int? ParentId;
            public Item(int id, int? parent = null)
            {
                Id = id;
                ParentId = parent;
            }
            public readonly List<Item> Children = new List<Item>();
        }
    }
