    class ImageType1 : IImageType
    {
      string Id {get; set;}
      string Name {get; set;}
      List<ImageType1Size> Sizes {get; set;} // This is just like Sizes1 = Sizes in the
                                             // example above.
    }
    public void Test(IImageSize imageSize)
    {
      IImageType imageType = new ImageType1();
      imageType.Add(imageSize) // This would compile, as IImageType.Sizes will 
                               // take any IImageSize
        
      // But what really happens behind the interface is this:
      ((ImageType1)imageType)Sizes.Add(imageSize);    
      // Trying to insert an IImageSize into the collection
      // doesn't work, because the compiler can't guarantee that 
      // it's an ImageType1Size
    }
