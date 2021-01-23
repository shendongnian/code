    private Color _color;                 // save the color somewhere
    private bool iKnowDaColor = false;    // this will be set to true when we know the color
    public Form1() {
        InitializeComponents();
        // on invalidate we want to be able to draw the rectangle
        panel1.Paint += new PaintEventHandler(panel_Paint);
    }
    void panel_Paint(object sender, PaintEventArgs e) {
        // if we know the color paint the rectangle
        if(iKnowDaColor) {
            e.Graphics.DrawRectangle(new Pen(_color),
                1, 1, 578, 38);
        }
    }
