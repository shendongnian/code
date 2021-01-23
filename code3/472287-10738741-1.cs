        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            panel1.BorderStyle = BorderStyle.FixedSingle;
            buffer = new Bitmap(panel1.Width,panel1.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.DrawRectangle(Pens.Red, 100, 100,100,100);
            }
            panel1.BackgroundImage = buffer;
            //writes the buffer Bitmap to a binary file, only neccessary if you want to save to disc
            ImageToDisc();
            //just to prove that it did write it to file and can be loaded I set the mainforms background image to the file
            this.BackgroundImage=FileToImage();
        }
        //Converts the image to a byte[] and writes it to disc
        public void ImageToDisc()
        {
            ImageConverter converter = new ImageConverter();
            File.WriteAllBytes(@"c:\test.dat", (byte[])converter.ConvertTo(buffer, typeof(byte[])));
        }
       
        //Converts the image from disc to an image
        public Bitmap FileToImage()
        {
            ImageConverter converter = new ImageConverter();
            return (Bitmap)converter.ConvertFrom(File.ReadAllBytes(@"c:\test.dat"));
        }
        
