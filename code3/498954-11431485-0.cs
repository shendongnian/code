    window1.Closing += Window_Closing;
    window2.Closing += Window_Closing;
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var w = (Window)sender;
        // Simple ref test to illustrate, but you can use anything else you want instead
        if (w == window1) {
            e.Cancel = true;
            w.Hide();
        }
    }
