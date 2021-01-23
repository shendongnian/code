    <Button Command="{Binding SaveCommand}" .... />
    private ICommand saveCommand; 
    public ICommand SaveCommand { 
        get { 
            if (saveCommand == null) {
                saveCommand = new RelayCommand(p => DoSave(), p=> CanSave() ); 
             } 
             return saveCommand; 
          } 
     }
