    private void OK_Button_Click(object sender, RoutedEventArgs e)
    {
        MyPublic variable = something;  //accessible after the dialog has closed.
        this.DialogResult = true;
    }
    
    private void Cancel_Button_Click(object sender, RoutedEventArgs e)
    {
         this.DialogResult = false;
    }
