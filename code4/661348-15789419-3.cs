    IEnumerable<Foo> list1 = new List<Foo>() { new Foo { ID = 1 }, new Foo { ID = 2 }, new Foo { ID = 3 } };
    IEnumerable<Foo> list2 = new List<Foo>() { new Foo { ID = 2 }, new Foo { ID = 3}, new Foo { ID = 4 } };
    IEnumerable<Foo> inBoth = list1.Intersect(list2);
    // now GetHashCode will be executed (not at list1.Intersect(list2))
    foreach (Foo fDup in inBoth)
        Console.WriteLine(fDup.ID);
