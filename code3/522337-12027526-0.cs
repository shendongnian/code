    public void DownloadFile(string item)
    {
        using (var client = new WebClient())
        {
            client.DownloadFile(
                 "http://www.lse.co.uk/chat/" + item,
                 @"..\..\sharePriceXML\" + item + ".xml"
            );
        }
        MessageBox.Show("Download Completed! File has been placed in the folder sharePriceXML!");
    }
