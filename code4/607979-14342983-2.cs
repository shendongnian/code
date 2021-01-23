    Dictionary<Int32, Class[]> dictionary = new Dictionary<Int32, Class[]>();
    
    list2.Reverse();
    for (Int32 i = 0; i < list1.Count; ++i)
        dictionary[i] = new Class[2] { list1[i], list2[i] };
