    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if (hasDataBeenModified)
        {
            if (System.Windows.Browser.HtmlPage.Window.Confirm("You have not reloaded the policies\nDo you want to do it now?"))
            {
                e.Cancel = true;
                ReloadButton_Click(null, null);
            }
        }
    }
