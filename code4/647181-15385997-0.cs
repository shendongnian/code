    private void VizualizareTest_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            Panel pan = new Panel();
            pan.Name = "panel" + i;
            ls.Add(pan);
            Label l = new Label();
            l.Text = "l"+i;
            pan.Controls.Add(l);
            this.Controls.Add(pan);
            
        }
    }
