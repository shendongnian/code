            var list1 = new List<string> {"a", "b"};
            var list2 = new List<string> {"a", "c"};
            List<string> addedItems = list2.Except(list1).ToList();
            addedItems.ForEach(x => Console.WriteLine("Added items: {0}", x));
            List<string> removedItems = list1.Except(list2).ToList();
            removedItems.ForEach(x => Console.WriteLine("Removed items: {0}", x));
