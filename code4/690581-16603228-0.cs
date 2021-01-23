    var list = new List<object> { "a", "b", "c", "d", "e", "a", "d" };
    for(int i=list.Count - 1; i >= 0; i--)
    {
       var obj = list[i];
       if(list.Take(i).Contains(obj))
           list.RemoveAt(i);
    }
