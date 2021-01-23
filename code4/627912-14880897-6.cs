    bool seen = false;
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i].ID == inputID)
        {
            items[i].Order = inputNewPosition;
            seen = true;
        }
    }
