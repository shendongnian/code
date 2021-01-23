    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        Bitmap backgroundImage = new Bitmap(asm.GetManifestResourceStream("Image913.jpg"));
        e.Graphics.DrawImage(
            backgroundImage, 
            this.ClientRectangle,
            new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height),
            GraphicsUnit.Pixel);
    }
