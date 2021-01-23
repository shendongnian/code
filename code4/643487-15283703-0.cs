    private void txtUrl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter)) {
            navigateTo(txtUrl.Text);
            webBrowser.focus(); // Hides the input box
        }
    }
