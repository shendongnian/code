    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen p = new Pen(Color.Red, 3))
        {
            // get the panel's Graphics instance
            Graphics gr = e.Graphics;
    
            // draw to panel
            gr.DrawLine(p, new Point(30, 30), new Point(80, 120));
            gr.DrawEllipse(p, 30, 30, 80, 120);
        }
    }
