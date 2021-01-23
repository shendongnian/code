            var list1 = new List<string> { "a", "b" };
            var list2 = new List<string> { "a", "c" };
            var addedItems = list2.Except(list1);
            addedItems.ForEach(x=>Console.WriteLine("Added items: {0}",x));
            var removedItems = list1.Except(list2);
            removedItems.ForEach(x => Console.WriteLine("Removed items: {0}", x));
