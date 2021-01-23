     List<int[]> list1 = new List<int[]>() { new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 5 } };
     List<int[]> list2 = new List<int[]>() { new int[2] { 1, 2 }, new int[2] { 3, 4 }, new int[2] { 3, 5 } };
     List<int[]> list3 = new List<int[]>();
     for (int i = 0; i < list1.Count; i++)
     {
        list3.Add(list1[i].Intersect(list2[i]).ToArray()); 
     }
