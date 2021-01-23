    private void button1_Click(object sender, EventArgs e)
    
    {
        Button[] b = new Button[4];
        for (int i = 0; i < 4; i++)
        {
            b[i] = new Button();
            b[i].Name = "button" + i;
            b[i].Location = new Point(43, 39 + 10 * i);
            b[i].Size = new Size(158, 48);
    
            b[i].Click += new EventHandler(OnClick);
            this.Controls.Add(b[i]);
        }
    }
    
    public void OnClick(object sender, EventArgs e)
    {
    
        MessageBox.Show("Hello Handler:" + ((Button)sender).Name );
    
    }
