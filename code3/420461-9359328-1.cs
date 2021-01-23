    public event DetailsViewUpdateEventHandler ItemUpdating; 
    public event DetailsViewUpdateEventHandler OnItemUpdating
    { 
       add { this.ItemUpdating += value;} 
       remove { this.ItemUpdating -= value;} 
    } 
