    private void Form1_Paint( object sender, PaintEventArgs e )
    {
        DrawStuff( e.Graphics );
    }
    private void trackBar1.Scroll( object sender, EventArgs e )
    {
        Graphics g = this.CreateGraphics();
    
        DrawStuff( g );
    
        g.Dispose();
    }
