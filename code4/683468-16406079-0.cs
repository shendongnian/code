        var image = new IMAGES
            {
                IMAGE = imageByteArray,
                IMAGE_NAME = pNum + "_OTHER.JPG",
                VIEWPOINT_ID = 279,
                ID_NO = ++id,
            };
        model.IMAGES.AddObject(image);
        try
        {
            model.SaveChanges();
            Trace.WriteLine("Saved: " + pNum + "_OTHER.JPG");
        }
        catch
        {
            image.VIEWPOINT_ID = 272;
            model.SaveChanges();
            Trace.WriteLine("Saved: " + pNum + "_OTHER.JPG");                
        }
