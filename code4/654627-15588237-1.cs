    Image returnImage;
    using (var ms = new MemoryStream(PictureFile))
    {
        returnImage = Image.FromStream(ms);
    }
    // leaving the using block closes ms
    var img = returnImage.Resize(size);
    // create new MemoryStream to save the resized image
    var resultStream = new MemoryStream();
    img.Save(resultStream, format);
    // rewind the stream
    resultStream.Seek(0, SeekOrigin.Begin);
    return resultStream;
