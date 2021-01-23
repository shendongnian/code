    int[] Array1 = { 09, 65, 87, 89, 888 };
    int[] Array2 = { 1, 13, 33, 49, 921 };
    int[] Array3 = { 22, 44, 66, 88, 110 };
    int [] MergeArr = Array1.Concat(Array2).Concat(Array3).ToArray();
    Array.Sort(MergeArr);
    int [] Top5Number = MergeArr.Reverse().Take(5).ToArray() 
