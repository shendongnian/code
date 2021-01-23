      void Form1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_lastClickedLinkLabel.Text == linkLabel1.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Dispose();
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb1.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
            if (_lastClickedLinkLabel.Text == linkLabel2.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb2.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
            if (_lastClickedLinkLabel.Text == linkLabel3.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb3.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
            if (_lastClickedLinkLabel.Text == linkLabel4.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb4.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
            if (_lastClickedLinkLabel.Text == linkLabel5.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb5.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
            if (_lastClickedLinkLabel.Text == linkLabel6.Text)
            {
                ((WebKitBrowser)tabControl1.SelectedTab.Controls[0]).PageScreenshot.Save("thumb6.png", ImageFormat.Png);
                // Do something here based upon the _lastClickedLinkLabel
            }
        }
