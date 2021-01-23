    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        MessageBoxResult res = MessageBox.Show("Are you sure that you want to exit?",
        "", MessageBoxButton.OKCancel);
        if (res != MessageBoxResult.OK)
        {
            e.Cancel = true;  //when pressed cancel don't go back
        }
    }
