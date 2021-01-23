    public Form1()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(Form1_Paint);
    }
    void Form1_Paint(object sender, PaintEventArgs e)
    {
        Pen pen = new Pen(Color.Aquamarine,2);
        SolidBrush brush = new SolidBrush(Color.Aquamarine);
        
        e.Graphics.DrawEllipse(pen, 10, 10, 100, 20);
        e.Graphics.FillEllipse(brush, 10, 50, 100, 20);
    }
