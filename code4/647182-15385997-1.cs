    private void VizualizareTest_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            Panel pan = new Panel();
            pan.Name = "panel" + i;
            ls.Add(pan);
            Label l = new Label();
            l.Text = "l"+i;
            pan.Location = new Point(10, i * 100);
            pan.Size = new Size(200, 90);  // just an example
            pan.Controls.Add(l);
            this.Controls.Add(pan);
            
        }
    }
