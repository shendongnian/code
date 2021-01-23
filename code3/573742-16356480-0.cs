            // Sample List<List<int>>
            var listList = new List<List<int>>();
            listList.Add(new List<int>() { 0, 1, 2, 3, 4 });
            listList.Add(new List<int>() { 0, 1, 2, 3, 4 });
            listList.Add(new List<int>() { 1, 1, 2, 3, 4 });
            listList.Add(new List<int>() { 1, 1, 1, 1, 1 });
            listList.Add(new List<int>() { 5, 6, 7, 8, 9 });
            // the List you are seaching for
            var searchList = new List<int>() { 10 };
            foreach(List<int> list in listList)
            {
                var newList =list.Intersect(searchList);
                if (newList.Count() == searchList.Count)
                {
                    string elements = "";
                    foreach (int item in newList)
                    {
                        elements += item + " ";
                    }
                    Console.WriteLine(elements);
                }
            }
            Console.ReadLine();
