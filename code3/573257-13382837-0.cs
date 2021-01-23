    public Box(EventHandler InsideEvent)
    {
        LabelDown.Text = null;
        LabelDown.Size = new Size(96, 32);
        LabelDown.Visible = true;
        LabelDown.Click += new EventHandler(InsideEvent);
        LabelDown.Tag = this;
        SavedID = 0;
    }
    void Box_goInside_Click(object sender, EventArgs e)
    {
        Box box = (Box)((Control)sender).Tag;
        
        // Do your stuff
    }
