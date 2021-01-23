    for(int i = download.Count; i >= 0; i--)
    {
        if (download[i].queryComplete())
        {
           // if download is no longer in progress it is removed from the list.
           download.RemoveAt(i);
        }
    }
