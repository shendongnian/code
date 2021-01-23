    int desiredLength = 6;
    foreach(....)
    {
        string sID = item.ProjectId.ToString();
        int paddingNeeded = desiredLength-sID.Length;
        if(paddingNeeded > 0)
        {
            sID = sID.PadLeft(paddingNeeded, '0');
        }
        //.....
    }
