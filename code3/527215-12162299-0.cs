    foreach (Control c in this.Controls)
    {
        if (c is SplitContainer)
        {
            Label tileTitle = new Label();
            tileTitle.Text = "OneClick";
            tileTitle.Visible = true;
            tileTitle.Location = new Point(10, 10);
    
            Label tileTitle2 = new Label();
            tileTitle2.Text = "OneClick";
            tileTitle2.Visible = true;
            tileTitle2.Location = new Point(10, 10);
            
            ((SplitContainer)c).Panel1.Controls.Add(tileTitle);
            ((SplitContainer)c).Panel2.Controls.Add((tileTitle2));
        }
    }
