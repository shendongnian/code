    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        //Store necessary painting data from e
        pictureBox1.Invalidate();
    }
    private void OnPaint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        //Handle painting logic
        base.OnPaint(e);
    }
