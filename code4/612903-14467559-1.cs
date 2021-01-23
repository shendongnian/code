    if (myItem1.Ranges.Count != myItem2.Ranges.Count)
    {
        return false;
    }
    for (int i = 0; i < myItem1.Ranges.Count; i++)
    {
        if (myItem1.Ranges[i].Min < myItem2.Ranges[i].Min ||
            myItem1.Ranges[i].Max > myItem2.Ranges[i].Max)
        {
            return false;
        }
    }        
    return true;
