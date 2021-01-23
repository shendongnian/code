    private void MessageBoxDismissed(object sender, DismissedEventArgs e)
    {
        CustomMessageBox messageBox = sender as CustomMessageBox;
        if (messageBox != null && e.Result == CustomMessageBoxResult.LeftButton)
        {
            TextBox tb = messageBox.Content as TextBox;
            if (tb != null && !string.IsNullOrEmpty(tb.Text.Trim()))
            {
               //do your stuff
            }
        }
        else
        {
        }
    }
