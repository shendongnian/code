    public interface IImageFetcher
    {
        IEnumerable<Image> FetchImages(string address);
    }
    public interface IImagePersistor
    {
        void StoreImage(Image image, string path);
    }
