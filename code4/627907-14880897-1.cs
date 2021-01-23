    bool found;
    for (int i = 0; i <= list.Count - 1; i++)
    {
        if (list[i].Id == inputID)
        {
            list[i].Order = inputNewPosition;
            found = true;
        }
        else
        {
            if (i < inputNewPosition)
            {
                 // do nothing
            }
            else if (found)
            {
                list[i].Order--;
            }
            else
            {
               list[i].Order++;
            }
        }
    }
