    protected override void OnBackKeyPress(CancelEventArgs e)
            {
                var result = MessageBox.Show("Do you want to exit?", "Attention!",
                                              MessageBoxButton.OKCancel);
    
                if (result == MessageBoxResult.OK)
                {
                    base.OnBackKeyPress(e);
                    return;
                }
                e.Cancel = true;
            }
