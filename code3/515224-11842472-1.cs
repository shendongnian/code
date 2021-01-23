    foreach (SPListItem item in myList.Items)
    {
        Console.WriteLine("Item {0}", item.Title);
        foreach(int bandNo in fieldLookup.Keys)
        {
            Console.WriteLine("Band {0}: {1}", bandNo, item[fieldLookup[bandNo]]);
        }
    }
