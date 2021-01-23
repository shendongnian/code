    public Image ImageToShow { get; set; }
    public ShowImageWindow()
    {
        InitializeComponent();
    }
    private void ShowImageWindow_Load(object sender, EventArgs e)
    {
        pictureBox1.Image = ImageToShow;
    }
