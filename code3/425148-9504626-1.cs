    public Form1()
    {
        InitializeComponent();
        Controls.Add(CreateBox(0, 0));
        AutoScroll = true;
    }
    
    Panel CreateBox(int X, int Y)
    {
        Panel panel = new Panel();
        panel.Location = new Point(X, Y);
        panel.Size = new Size(100, 150);
    
        RichTextBox rtb = new RichTextBox();
        panel.Controls.Add(rtb);
    
        Button b = new Button();
        b.Location = new Point(10, 100);
        b.Tag = rtb;
        b.Click += AllButtons_Click;
        panel.Controls.Add(b);
    
        return panel;
    }
    
    int i = 0;
    void AllButtons_Click(object sender, EventArgs e)
    {
        ((RichTextBox)((sender as Button).Tag)).Text = "Clicked";
        i += 150;
        Controls.Add(CreateBox(0, i));
    }
