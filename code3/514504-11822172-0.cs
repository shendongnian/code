    string[] textlist = {"a", "b", "c"};
    var intersecting = from aIndex in Enumerable.Range(0, textlist.Count())
                       from b in textlist.Skip(aIndex + 1)
                       let a = textlist.ElementAt(aIndex)
                       where a != b //&& a.SomeCondition(b)
                       select new
                       {
                           object1 = a,
                           object2 = b
                       };
