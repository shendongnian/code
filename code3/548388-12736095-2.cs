    interface IImage
    {
        IEnumerable<IImageSize> Sizes { get; }
    }
    class ImageType1
    {
        public List<ImageType1Size> SizeList { get; private set; }
        public IEnumerable<IImageSize> Sizes { get { return SizeList; } }
    }
