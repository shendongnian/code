    // read in all the frames
    GifDecoder decoder = new GifDecoder();
    ImageInfo info = decoder.GetImageInfo(mySourceStream);
    GifFrameCollection collection = decoder.Frames;
    foreach (GifFrameFrame frame in collection)
    {
        // resize each frame
        AtalaImage image = frame.Image;
        AtalaImage resizedImage = new ReampleCommand(new Size(newWidth, newHeight)).Apply(image).Image;
        frame.Image = resizedImage;
    }
    // set the size in the collection
    collection.Width = newWith;
    collection.Height = newHeight;
    
    // save out to a stream
    GifEncoder encoder = new GifEncoder();
    encoder.Save(outputStream, collection, null);
