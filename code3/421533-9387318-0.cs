    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        TextRenderer.DrawText(e.Graphics, 
                              "Some Text", 
                              this.Font, 
                              new Point(10, 10), 
                              SystemColors.ControlText);
    }
