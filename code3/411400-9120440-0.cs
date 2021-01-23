    public Form1()
    {
        InitializeComponent();
        Resize += Form1_Resize;
    }
    
    void Form1_Resize(object sender, EventArgs e)
    {
        pictureBox1.Size = new Size(Width / 2, Height / 2);
    }
