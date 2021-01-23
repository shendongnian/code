    //Message is the string message and options is where you specify RTL
    public void ShowMessageBox(string message, MessageBoxOptions options)
    {
        MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcons.None, MessageBoxDefaultButton.Button1, options);
    }
