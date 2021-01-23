    ICommand UpdateSelectedItemCommand {get;set;}
    
    ..
    
    UpdateSelectedItemCommand = new DelegateCommand( (param) =>
    {
       State= (States) param;
    });
