    list1.Sort();
    list2.Sort();
    list3.Sort();
    var result = new List<List<int>>();
    if(!result.Any(elm => elm.SequenceEqual(list1)))
        result.Add(list1);
    if(!result.Any(elm => elm.SequenceEqual(list2)))
        result.Add(list2);
    if(!result.Any(elm => elm.SequenceEqual(list3)))
        result.Add(list3);
