    // create an instance of blob counter algorithm
    BlobCounterBase bc = new ...
    // set filtering options
    bc.FilterBlobs = true;
    bc.MinWidth  = 5;
    bc.MinHeight = 5;
    // process binary image
    bc.ProcessImage( image );
    Blob[] blobs = bc.GetObjects( image, false );
    // process blobs
    var rectanglesToClear = from blob in blobs select blob.Rectangle;
                               
     using (var gfx = Graphics.FromImage(image))
     {
        foreach(var rect in rectanglesToClear) 
        {
            if (rect.Height < someMaxHeight && rect.Width < someMaxWidth)
                gfx.FillRectangle(Brushes.Black, rect);
        }
      gfx.Flush();
     }
