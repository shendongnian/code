    SortedList list = ...
    var listEnumerator = ((IEnumerable)list).GetEnumerator();
    listEnumerator.MoveNext();
    listEnumerator.MoveNext();
    var twoPositionsNext = listEnumerator.Current;
