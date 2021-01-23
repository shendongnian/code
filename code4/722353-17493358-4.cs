    // For testing purposes only.
    class DummyImagePersistor
    {
        public readonly List<string> Filenames = new List<string>();
        public void StoreImage(Image image, string path)
        {
            Filenames.Add(path);
        }
    }
