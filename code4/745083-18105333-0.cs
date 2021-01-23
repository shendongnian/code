    var list = new List<T>();
    list.AddRange(list1);
    list.AddRange(list2);
    list.AddRange(list3);
    list.AddRange(list4);
    foreach (T item in list)
    {
        .....
    }
