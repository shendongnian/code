    //Define your command
    public ICommand ChangeFirstNameCommand {get;set;}
    //Initialize your command in Constructor perhaps
    ChangeFirstNameCommand = new RelayCommand(OnChangeFirstName,CanChangeFirstName);
    
    private void OnChangeFirstName()
    { 
        //Your FirstName TextBox in your V will be updated after you click the Button
        this.FirstName = "Gennady"
    }
    
    private bool CanChangeFirstName()
    {
      //Add any validation to set whether your button is enabled or not. WPF internals take care of this.
      return true;
    }
