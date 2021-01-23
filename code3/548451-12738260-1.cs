    var result = from i in
                Enumerable.Range(0, Math.Min(list1.Count, list2.Count))
                select list1.ElementAtOrDefault(i) + list2.ElementAtOrDefault(i);
    foreach (var item in result)
    {
    Debug.Write(item.Value);
    }
