    Bitmap buffer; 
    public Form1()
    {
        InitializeComponent();
        panel1.BorderStyle = BorderStyle.FixedSingle;
        buffer = new Bitmap(panel1.Width,panel1.Height);
        //Make sure you resize your buffer whenever the panel1 resizes.
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics g = Graphics.FromImage(buffer))
        {
            g.DrawRectangle(Pens.Red, 100, 100,100,100);
        }
        panel1.BackgroundImage = buffer;
    }
