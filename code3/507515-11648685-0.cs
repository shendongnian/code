    var listToRemove = new List<T>(originalList);
    foreach (var item in originalList)
    {
        ...
        if (...)
        {
            listToRemove.Add(item)
        }
        ...
    }
    foreach (var item in listToRemove)
    {
        originalList.Remove(item);
    }
