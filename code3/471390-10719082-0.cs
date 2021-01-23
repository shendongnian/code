    foreach (var node in nodes)
    {
        ...
        LinkLabel ll = new LinkLabel();
        ...
        ll.Click += MyLabelClickHandler;
        this.Controls.Add(ll);
        
        i++;
    }
    void MyLabelClickHandler(object sender, Eventargs e)
    {
        senderLabel = sender as LinkLabel;
        string text = senderlabel.text;
        ....
    }
