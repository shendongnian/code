    string[] links = new string[10];
    TableLayoutPanel panel = new TableLayoutPanel();
    panel.RowCount = links.Length;
    panel.ColumnCount = 1;
    int currentRow = 0;
    foreach (var link in links)
    {
    	LinkLabel linkLabel = new LinkLabel();
    	linkLabel.Text = "Click here to get more info.";
    	linkLabel.Links.Add(6, 4, link);
        linkLabel.OnLinkClicked += OnLinkClicked;
    	panel.Controls.Add(linkLabel, 0, currentRow++);
    }
    this.Controls.Add(panel);
