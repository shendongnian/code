    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        //change the event to avoid close form
        e.Cancel = true;
    }
