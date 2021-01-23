    public void PlumbTheCode()
    {
        this.Items.Clear();
        this._LoadColor = new LoadColorDelegate(newItem.LoadColorPlumbed);
        foreach (XmlNode node in doc.ChildNodes)
        {
            this.AddChild(new XMLTreeViewItem(node, this));
        }
    }
