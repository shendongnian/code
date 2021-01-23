    public Form1()
    {
        InitializeComponent();
        Controls.Add(CreateBox(0, 0));
        Controls.Add(CreateBox(100, 0));
    }
    
    Panel CreateBox(int X, int Y)
    {
        Panel panel = new Panel();
        panel.Location = new Point(X, Y);
        panel.Size = new Size(100, 200);
    
        RichTextBox rtb = new RichTextBox();
        panel.Controls.Add(rtb);
    
        Button b = new Button();
        b.Location = new Point(10, 100);
        b.Tag = rtb;
        b.Click += AllButtons_Click;
        panel.Controls.Add(b);
    
        return panel;
    }
    
    void AllButtons_Click(object sender, EventArgs e)
    {
        ((RichTextBox)((sender as Button).Tag)).Text = "Clicked";
    }
