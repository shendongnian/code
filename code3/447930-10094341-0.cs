    List<int> list1 = new List<int>() { 0,2,6,9,10 };
    int must_enter = 4;
    
    for (int i = 0; i < list1.Count; i++)
    {
         if (!list1.Contains(i))
         {
             list1.Insert(i , i);
         }
    }
