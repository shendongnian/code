    var list1 = new string[] { "A", "B", "C" };
    var list2 = new string[] { "B", "A", "C" };
    var list3 = new string[] { "C", "B", "A" };
    var hs = new HashSet<string>(list1);
    if (list2.All(x => hs.Contains(x)) && list3.All(x => hs.Contains(x)))
    {
                
    }
