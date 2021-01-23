    private string FileName;
    public Form1()
    {
        InitializeComponent();
        FileName = "";
    }
    // OPEN FILE btn 
    private void button1_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
             
            FileName = openFileDialog1.FileName;
            setImage();
        }
    }
    // REFRESH btn 
    private void button2_Click(object sender, EventArgs e)
    {
        if (FileName != "")
        {
            setImage();
        }
    }
    private void setImage()
    {
    Bitmap tempImg;
        using( tempImg= new Bitmap(FileName))
        {
        Rectangle rect = new Rectangle(0, 0, 100, 100);
        PixelFormat format = tempImg.PixelFormat;
        this.BackgroundImage = new Bitmap(FileName).Clone(rect, format);
        }
    }
    
