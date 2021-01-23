    private void historyMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();  // create new xml document
            doc.Load("..\\history.xml");  // load the xml
            XmlNodeList nodeList = doc.SelectNodes("URLs/http");  // create a new node list
                                                                  // and select nodes from BookItems/Book
            historyMenuItem.DropDownItems.Clear();
            foreach (XmlNode node in nodeList)   // for each node in the node list
            {
                string page = node.Attributes["page"].Value;
                
                ToolStripMenuItem windowNewMenu = new ToolStripMenuItem(page, null, new EventHandler(MenuItemClickHandler));
                windowMenuItem.Tag = page;
                historyMenuItem.DropDownItems.Add(windowNewMenu);
            }
        }
    private void MenuItemClickHandler(object sender, EventArgs e)
    {
        ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
  
        UrlTextBox.Text = (string)clickedItem.Tag;
        this.thread = new Thread(new ThreadStart(this.httpRequestMultiThread));
        this.thread.Start();
    }
