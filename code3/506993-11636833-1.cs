    List<List<int>> myNestedList = new List<List<int>>();
    int iOuter=-1;
    foreach (var t in myFlattenedList)
    {
        if (iOuter != t.Item1)
            myNestedList.Add(new List<Int>());
        iOuter = t.Item1;
        myNestedList[t.Item1][t.Item2] = t.Item3;
    }
