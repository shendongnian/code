    List<int> matchingIndexes = new List<int>();
    for(int i=0; i<list.Count; i++)
    {
        if (item == tbItem.Text)
            matchingIndexes.Add(i);
    }
    
    //Now iterate over the matches
    foreach(int index in matchingIndexes)
    {
        list[index] = "newString";
    }
