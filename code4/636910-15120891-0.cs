    private void button1_Click(object sender, EventArgs e)
    {
        if (!panel1.AutoScroll) panel1.AutoScroll = true;
        for (int i = 0; i < 3; i++)
        {
            Textbox txt = new TextBox() { Location = new Point(3, (panel1.Controls.Count * 25) + 3 };
            panel1.Controls.Add(txt);
        }
    } 
