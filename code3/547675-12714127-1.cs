     public GenericCommand MyCommand { get; set; }
     MyCommand = new GenericCommand();
     MyCommand.CanExecuteFunc = obj => true;
     MyCommand.ExecuteFunc = obj => MyMethod;
     private void MyMethod(object parameter)
     {
          //define your command here
     }
