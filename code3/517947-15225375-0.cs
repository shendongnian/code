    if (tabControl1.SelectedTab.Text == "+")
            {
                AddNewTab();
            }
            foreach (Control item in tabControl1.SelectedTab.Controls)
            {
                if (item.GetType() == typeof(WebBrowser))
                {
                    WebBrowser wb = (WebBrowser)item;
                    toolStripButton1.Enabled = wb.CanGoBack;
                    toolStripButton2.Enabled = wb.CanGoForward;
                }
            }
