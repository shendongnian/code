    Image returnImage;
    using (var ms = new MemoryStream(PictureFile))
    {
        returnImage = Image.FromStream(ms);
    }
    // leaving the using block closes ms
    var img = returnImage.Resize(size);
    var resultStream = new MemoryStream(); // new MemoryStream
    img.Save(resultStream, format);
    resultStream.Seek(0, SeekOrigin.Begin); // rewind
    return resultStream;
