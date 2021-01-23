    class LocalBitmap
    {
        public Bitmap Bitmap { get; set; }
        public String Path { get; set; }
        public LocalBitmap(String path)
        {
            Path = path;
            Bitmap = new Bitmap(path);
        }
    }
