    var existing = new HashSet<Tuple<string, string>>();
    for (int i = myList.Count - 1; i >= 0; i--)
    {
        if (existing.Contains(myList[i]))
        {
            myList.RemoveAt(i);
        }
        else
        {
            existing.Add(myList[i]);
        }
    }
