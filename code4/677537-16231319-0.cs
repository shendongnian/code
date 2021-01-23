    int max = aList.Count > bList.Count ? aList.Count : bList.Count;
    for(int i = 0; i < max; ++i)
    {
        if(i < aList.Count)
            Write(aList[i]);
        if(i < bList.Count)
        {
            if(i < aList.Count)
                Write(aList[i] == bList[i] ? bList[i] : "");
            else
                Write(bList[i]);
        }
    }
