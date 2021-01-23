    ICommand ClickMeCommand {get;set;}
    private void InitCommands()
    {
       ClickMeCommand = new RelayCommand(()=>HasBeenClicked=true);
       //or
       ClickMeCommand = new RelayCommand(ClickMeEvent);
    }
    public void ClickMeEvent()
    {
       HasBeenClicked=true;
    }
