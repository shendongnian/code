    public static void GetItemsBasedOn(GetItemOptions getItemOption)
    {
        if (getItemOption.HasFlag(GetItemOptions.SortByOldest) && getItemOption.HasFlag(GetItemOptions.SortByLatest))
            throw new ArgumentException("I can't sort by both...");
    
        if (getItemOption.HasFlag(GetItemOptions.Read))
        {
            Console.WriteLine("READ");
        }
    
        if (getItemOption.HasFlag(GetItemOptions.Unread))
        {
            Console.WriteLine("UNREAD");
        }
    
        if (getItemOption.HasFlag(GetItemOptions.SortByOldest))
        {
            Console.WriteLine("SORT BY OLDEST");
        }
        else if (getItemOption.HasFlag(GetItemOptions.SortByLatest))
        {
            Console.WriteLine("SORT BY NLATEST");
        }
    }
