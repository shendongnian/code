    int index = 0;
    while(index != -1)
    {
        index = -1;
        for(int i = 0; i< lines.Count(); i++)
        {
            if(lines[i].Contains(sitetounblock))
            {
                index = i;
                break;
            }
        }
        if(index != -1)
            lines.RemoveAt(i);
    }
