    for (int i = Contents.Count - 1; i >= 0; i--)
    {
        if (IDS.Contains(Contents[i].ID)) //Check if the ID has already been used in Contents
        {
            Contents.RemoveAt(i);
        }
    }
