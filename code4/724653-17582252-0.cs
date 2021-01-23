            List<string> SortingList = new List<string>();
        using (StreamReader r = new   StreamReader("DistinctItemsNoBlankLines.txt"))
                            {
                            string line;
                            while ((line = r.ReadLine()) != null)
                                {
                                    SortingList.Add(line);
                                }
                            }
           
            
       List<string>DistinctSortingList = SortingList.Distinct().ToList();
        
            foreach (string str in DistinctSortingList)
            {
           
            int index = 0;
                while ( index < DistinctSortingList.Count() -1)
                {
                if (DistinctSortingList[index] == DistinctSortingList[index + 1])
                    DistinctSortingList.RemoveAt(index);
                else
                    index++;
                }
            }
             txtDistinctItems.Lines = DistinctSortingList.ToArray();
