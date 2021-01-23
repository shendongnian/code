    if (Microsoft.VisualBasic.Information.IsNumeric(mystring))
    {
        var newWindow = new MainWindow();
        newWindow.Show();
    }
    else
    {
        label1.Text = mystring;
    }
