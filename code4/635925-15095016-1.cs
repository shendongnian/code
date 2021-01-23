    private bool state = false; 
    private void moveTimer_Tick(object sender, System.EventArgs e)
    {
        //Move text to new Location
        //textLabel.Left = rand.Next(Math.Max(1, Bounds.Width - textLabel.Width));
        //textLabel.Top = rand.Next(Math.Max(1, Bounds.Height - textLabel.Height));
        if (state)
        {
            pictureBox1.Hide();
            textLabel.Show();
        }
        else
        {
            textLabel.Hide();
            pictureBox1.Show();
        }
        state = !state;
    }
