    private void BigClientsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        MyClient c = BigClientsList.SelectedItem as MyClient;
        if (c != null && !String.IsNullOrWhiteSpace(c.UrlAddress))
        {
            string url = c.ClientName;
            Process.Start("iexplorer.exe",url);
        }
        else
        {
            // do something different if they select a list item without a Client instance or URL
        }
    }
