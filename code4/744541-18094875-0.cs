    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        if (MessageBox.Show("Are you sure that you want to exit?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            e.Cancel = true;
        else
            base.OnBackKeyPress(e);
    }
