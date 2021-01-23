    foreach (SplitContainer sp in this.Controls.OfType<SplitContainer>())
    {
        Label title = MakeLabel("OneClick", new Point(10, 10);
        sp.Panel1.Controls.Add(title);
        Label title1 = MakeLabel("OneClick", new Point(10, 10);
        sp.Panel2.Controls.Add(title);
    }
    
    private Label MakeLabel(string caption, Point position)
    {
        Label lbl = new Label();   
        lbl.Text = caption;   
        lbl.Location = position;   
        lbl.Visible = true;   
        return lbl;
    }
