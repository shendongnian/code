    private void UserControl_Loaded(object sender, RoutedEventArgs e)     
    {
        // Get the viewmodel from the DataContext
        MyViewModel vm = this.DataContext as MyViewModel;
    
        //Call command from viewmodel     
        if ((vm != null) && (vm.MyCommandCanExecute(null)))
            vm.MyCommand.Execute(null);
    } 
