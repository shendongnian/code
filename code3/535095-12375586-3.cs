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
    Stream str=new FileStream(FileName,FileMode.Open, FileAccess.Read,FileShare.Read);
            Bitmap tempImg= new Bitmap(Bitmap.FromStream(str));
            str.Close();
            using( tempImg)
            {
                
            Rectangle rect = new Rectangle(0, 0, tempImg.Width, tempImg.Height);
                
            PixelFormat format = tempImg.PixelFormat;
            this.BackgroundImage = new Bitmap(tempImg);
            
            }
    }
    
