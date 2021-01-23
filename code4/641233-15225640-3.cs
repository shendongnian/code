    public bool OnMenuItemClick(IMenuItem item)
    {
        switch (item.ItemId)
        {
            case Resource.Id.item1: 
                    //Do stuff for item1
                    return true;
            case Resource.Id.item2: 
                    //Do stuff for item2
                    return true;
            case Resource.Id.item3:
                    //Do stuff for item3
                    return true;
            default:
                    return false;
         }
    }
