    int j = 0;
    for (int i = 0; i < list.Count && j < toRemove.Count; i++)
    {
        if (list[i] == toRemove[j])
        {
            list.RemoveAt(i);
            j++;
            i--;
        }
    }
