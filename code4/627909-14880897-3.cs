    bool seen;
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i].ID == inputID) // case 1
        {
            items[i].Order = inputNewPosition;
            seen = true;
        }
        else if (seen) // cases 4 & 5
        {
            if (items[i].Order <= inputNewPosition) // case 4
            {
               items[i].Order--; // move it left
            }
        }
        else // case 2 & 3
        {
            if (items[i].Order >= inputNewPosition) // case 3
            {
                items[i].Order++; // move it right
            }            
        }
    }
