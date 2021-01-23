            List<int> list2 = new List<int>() { 1, 2, 3, 5, 6 }; // missing: 0 and 4
            List<int> list1 = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            int number = 3; // starting position
            int indexer = list2.BinarySearch(number);
            if (indexer < 0)
            {
                list2.Insert(~index, number); // don't look at this part
            }
            // get indexes of "starting position"
            int index1 = list1.Select((item, i) => new { Item = item, Index = i }).First(x => x.Item == number).Index;
            int index2 = list2.Select((item, i) => new { Item = item, Index = i }).First(x => x.Item == number).Index;
            // reorder lists starting at "starting position"
            List<int> reorderedList1 = list1.Skip(index1).Concat(list1.Take(index1)).ToList(); //main big
            List<int> reorderedList2 = list2.Skip(index2).Concat(list2.Take(index2)).ToList(); // main small
            int end = 2; // get ending position: 2 numbers to the right
            int end_num = reorderedList2[end]; // get ending number
            int endlist1 = reorderedList1.IndexOf(end_num); // ending position
            //get lists for comparison
            reorderedList2 = reorderedList2.Take(end + 1).ToList();
            reorderedList1 = reorderedList1.Take(endlist1 + 1).ToList();
            //compare lists
            var list3 = reorderedList1.Except(reorderedList2).ToList();
            if (list3.Count != 0)
            {
                foreach (int item in list3)
                {
                    list1 = list1.Where(x => x != item).ToList(); // remove from list
                }
            }
            // list1 is the result that I wanted to see
