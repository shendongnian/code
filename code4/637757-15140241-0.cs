    class Item
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            // Create some items
            var item1 = new Item {Value = 0, Text = "a"};
            var item2 = new Item {Value = 0, Text = "b"};
            var item3 = new Item {Value = 1, Text = "c"};
            var item4 = new Item {Value = 1, Text = "d"};
            var item5 = new Item {Value = 2, Text = "e"};
            // Add items to the list
            var itemList = new List<Item>(new[] {item1, item2, item3, item4, item5});
            // Split items into groups by their Value
            // Result contains three groups.
            // Each group has a distinct groupedItems.Key --> {0, 1, 2}
            // Each key contains a collection of remaining elements: {0 --> a, b} {1 --> c, d} {2 --> e}
            var groupedItemsByValue = from item in itemList
                                      group item by item.Value
                                      into groupedItems
                                      select groupedItems;
            // Take first element from each group: {0 --> a} {1 --> c} {2 --> e}
            var firstTextsOfEachGroup = from groupedItems in groupedItemsByValue
                                        select groupedItems.First();
            // The final result
            var distinctTexts = firstTextsOfEachGroup.ToList(); // Contains items where Text is: a, c, e
        }
    }
