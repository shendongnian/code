    public Form1()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(Form1_Paint);
    }
    void Form1_Paint(object sender, PaintEventArgs e)
    {
        Pen pen = new Pen(Color.Aquamarine,2);
        e.Graphics.DrawEllipse(pen, 10, 10, 100, 20);
    }
