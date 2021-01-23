    int crTextColor;
    
    public Form1()
    {
        InitializeComponent();
        BackColor = Color.Aqua;
        crTextColor = BackColor.ToArgb();//To number
        Text = crTextColor.ToString();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        BackColor = Color.FromArgb(crTextColor);//From number
    }
