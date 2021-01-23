    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        //Optional - first test if the DataContext is not a MyViewModel
        if( !this.DataContext is MyViewModel) return;
        //Optional - check the CanExecute
        if( !((MyViewModel) this.DataContext).MyCommand.CanExecute(null) ) return;
        //Execute the command
        ((MyViewModel) this.DataContext).MyCommand.Execute(null)
    }
