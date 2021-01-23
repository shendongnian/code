    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        switch (item.ItemId)
        {
            case 0: //Do stuff for button 0
                    return true;
            case 1: //Do stuff for button 1
                    return true;
            default:
                    return base.OnOptionsItemSelected(item);
         }
    }
