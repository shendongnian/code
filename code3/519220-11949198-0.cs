    private bool SearchFilter(object sender)
    {
        CommDGDataSource item = sender as CommDGDataSource;
        if (FilterPropertyList.IsErrorFilter && !item.Error)
            return false;
        if (FilterPropertyList.IsDestinationFilter && item.Destination != FilterPropertyList.Destination)
            return false;
        if (FilterPropertyList.IsSourceFilter && item.Source != FilterPropertyList.Source)
            return false;
        return true;
    }
