    var list1 = new[] { "A", "B", "C" };
    var list2 = new[] { "B", "C", "D" };
    var list3 = new[] { "C", "D", "E" };
    FindUniques(new[] { list1, list2, list3 }); // { "A", "E" }
    IntersectAll(new[] { list1, list2, list3 }); // { "C" }
