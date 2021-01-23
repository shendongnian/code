    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        e.Graphics.DrawImage(Image.FromFile("map.png"), new Point(0, 0))
        e.Graphics.DrawImage(Image.FromFile("car.png"), car.Position)
    }
    public void Update()
    {
        // Update the game here
        this.Invalidate(); // Invalidating the form will force it to redraw its graphics
    }
