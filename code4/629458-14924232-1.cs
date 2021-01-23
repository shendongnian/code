    public void Form1()
    {
         Paint += Form1_Paint;
    }
    public void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(SystemColors.Control);
        DrawOverlappingLabels(e, *new point for label 1*, *new point for label 2*);
    }
    private void DrawOverlappingLabels(PaintEventArgs e, _
        Point positionLabel1, Point positionLabel2)
    {
        var graphics = e.Graphics();
        var rectLabel1 = new Rectangle(new positionLabel1, new Size(150, 30));
        var rectLabel2 = new Rectangle(new positionLabel2, new Size(150, 30));
        graphics.DrawString("Label1", new Font(Font.FontFamily, 24f), _
            new SolidBrush(Color.Black), rectLabel1);
        
        graphics.DrawString("Label2", new Font(Font.FontFamily, 8f), _ 
            new SolidBrush(Color.Black), rectLabel2);
    }
