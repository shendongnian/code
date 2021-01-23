    int j = 0;
    for (int i = 0; i < list.Count && j < toRemove.Count; i++)
    {
        var currRemove = toRemove[j];
        while (list[i] == currRemove)
        {
            list.RemoveAt(i);
            i--;
        }
        j++;
    }
