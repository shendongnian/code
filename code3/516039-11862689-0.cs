    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        Stream myStream = myAssembly.GetManifestResourceStream("EmbeddingExample.image1.bmp");
        Bitmap image = new Bitmap(myStream);
        this.ClientSize = new Size(image.Width, image.Height);
        PictureBox pb = new PictureBox();
        pb.Image = image;
        pb.Dock = DockStyle.Fill;
        this.Controls.Add(pb);
    }
