    class MyImage
    {
        public Bitmap Image { get; set; }
        public string Path { get; set; }
        public MyImage(string path)
        {
            Path = path;
            Image = new Bitmap(path);
        }
    }
