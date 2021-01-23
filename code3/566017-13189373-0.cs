    SortedList<decimal, Traits> listA = new SortedList<decimal, Traits>();
    SortedList<decimal, Traits> listB = new SortedList<decimal, Traits>();
    listA.Add(1m, new Traits { FieldName = "One" });
    listA.Add(2m, new Traits { FieldName = "Two" });
    listA.Add(3m, new Traits { FieldName = "Three" });
    listB.Add(1m, new Traits { FieldName = "One" });
    listB.Add(4m, new Traits { FieldName = "Four" });
    listB.Add(5m, new Traits { FieldName = "Five" });
    var listUnion = listA.Union(listB).ToLookup(k => k.Key, v => v.Value)
                         .ToDictionary(k => k.Key, v => v.First());
    var listMerged = new SortedList<decimal, Traits>(listUnion);
