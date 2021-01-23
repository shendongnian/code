    for (int i = 0; i < list.Count; i++)
    {
        CheckBox c = new CheckBox();
        c.Text = "";
        c.Tag = i.ToString();
        c.Width = 120;
        flowLayoutPanel1.Controls.Add(c);
        c.Paint += new PaintEventHandler(c_Paint);
                    
    }
        flowLayoutPanel1.Enabled = false;
