    private void button1_Click(object sender, EventArgs e)
    {
    panel1.Controls.Clear();
    
    
    //Then add your existing code below
    serControl1 x1 = new UserControl1();
        UserControl2 x2 = new UserControl2();
        UserControl3 x3 = new UserControl3();
    
        x1.Location = new Point(panel1.AutoScrollPosition.X , panel1.AutoScrollPosition.Y);
        x2.Location = new Point(panel1.AutoScrollPosition.X , panel1.AutoScrollPosition.Y + x1.Size.Height);
        x3.Location = new Point(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y + x1.Size.Height + x2.Size.Height);
    
        panel1.Controls.Add(x1);
        panel1.Controls.Add(x2);
        panel1.Controls.Add(x3);
    }
