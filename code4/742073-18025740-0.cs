    private void button1_Click(object sender, EventArgs e)
    {
    
        int y = 100;
        int x = 70;
        for (int i = 0; i < numericUpDown1.Value; i++)
        {
            var txtbx = new TextBox();
            txtbx.AutoSize = true;
            Controls.Add(txtbx);
            txtbx.Location = new Point(x, y);
            
            // Increase the y-position for next textbox.
            y += 30;
        }
    }
