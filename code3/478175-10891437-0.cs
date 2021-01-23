    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        DrawBackground();
    }
    public void DrawBackground()
    {
        Graphics SimWindow = pictureBoxSimDisplay.CreateGraphics();
        SolidBrush brush = new SolidBrush(Color.Green);
        SimWindow.FillRectangle(brush, 0, 211, 491, 5);
        SimWindow.Dispose(); // Don't forget to dispose your Graphic Object
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Start();
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        Invalidate();
    } 
