    private void ExecuteLoginCommand(object parameter)
    {
          bool loginOk = Login(.....);
          if(loginOk)
             viewService.NavigateTo(new MainWindowViewModel);
          else
             viewService.ShowMessage("Login failed");
    }
