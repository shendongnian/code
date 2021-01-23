    public event DetailsViewUpdateEventHandler ItemUpdating; 
    public event DetailsViewUpdateEventHandler OnItemUpdating
    { 
       add{ UserControl_UCDetailsView.ItemUpdating += value;} 
       remove { UserControl_UCDetailsView.ItemUpdating -= value;} 
    } 
