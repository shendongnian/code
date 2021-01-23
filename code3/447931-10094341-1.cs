    List<string> list = new List<string>{0,2,6,9,10};
    for (int i = 0; i < list1.Count; i++)
    {
       int index = list.BinarySearch(i);
       if( i < 0)
       {
        int insertIndex = ~index; 
        list.Insert(insertIndex, i);
       }
    }
