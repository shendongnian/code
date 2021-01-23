    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Font myFont = new Font("Arial", 14))
        {
            e.Graphics.DrawString("Hello .NET Guide!", myFont, Brushes.Green, new Point(2, 2));
        }
    }
