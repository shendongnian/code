    var result = new List<List<int>>();
    if(!result.Any(elm => elm.OrderBy(i=>i).SequenceEqual(list1.OrderBy(i=>i))))
        result.Add(list1);
    if(!result.Any(elm => elm.OrderBy(i=>i).SequenceEqual(list2.OrderBy(i=>i))))
        result.Add(list2);
    if(!result.Any(elm => elm.OrderBy(i=>i).SequenceEqual(list3.OrderBy(i=>i))))
        result.Add(list3);
