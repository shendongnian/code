    static int Main(string[] args)
    { 
        PicturesCollection pictures = new PicturesCollection();
        pictures.PictureAdded += Pictures_PictureAdded;
    }
    
    static void Pictures_PictureAdded(object sender, PictureAddedEventArgs e)
    {
        if (e.Name == "Me")
            PictureBox1.Image = Image.fromFile("");
    }
