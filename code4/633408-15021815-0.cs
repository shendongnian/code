    if(this.Dispatcher.CheckAccess())
    {
        InteractionService.UserInteration.DisplayPopup(...);
    }
    else
    {
        this.Dispatcher.Invoke(()=>this.CallerID());
    }
