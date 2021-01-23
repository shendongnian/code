    private void rtbLog_LinkClicked(object sender, LinkClickedEventArgs e)
    {
                try
                {
                    var link = e.LinkText.Replace("%20", " ");
                    System.Diagnostics.Process.Start(link);
                }
                catch (Exception)
                {
                }
    }
