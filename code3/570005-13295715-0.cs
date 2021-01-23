    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        //Only move if the left button still down  
        if (e.Button == MouseButtons.Left)
        {
            button1.Location = new Point(button1.Location.X + (e.X - OldPosition.X), button1.Location.Y + (e.Y - OldPosition.Y));
             
            //CHECK IF NEW LOCATION IS WITHIN PANEL BOUNDS
                if (panel1.Bounds.Contains(button1.Location))
                    panel1.BackColor = Color.Red;
                else
                    panel1.BackColor = Color.Green;
        }
    }
