    interface IImage
    {
      string Name
    }
    interface IImage<TSize> : IImage where TSize : IImageSize
    {
        List<TSize> Sizes { get; }
    }
    
    class ImageType1 : IImage<ImageType1Size>
    {
        List<ImageType1Size> Sizes { get; private set; }
    }
