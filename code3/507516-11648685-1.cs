    var iterationList = new List<T>(originalList);
    for (int i = 0; i < iterationList.Count; i++)
    {
        ...
        if (...)
        {
            originalList.RemoveAt(i);
        }
        ...
    }
