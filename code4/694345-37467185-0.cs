    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
     
    using A = DocumentFormat.OpenXml.Drawing;
    using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
    using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
    
    // Select element containing picture control and get the blip element
    
    Bitmap image = new Bitmap(@"F:insert_me.jpg");
    SdtElement controlBlock = _mainDocumentPart.Document.Body
        .Descendants<SdtElement>()
            .Where
            (r => 
                r.SdtProperties.GetFirstChild<Tag>().Val == tagName
            ).SingleOrDefault();
    // Find the Blip element of the content control.
    A.Blip blip = controlBlock.Descendants<A.Blip>().FirstOrDefault();
    
    
    // Add image and change embeded id.
    ImagePart imagePart = _mainDocumentPart
        .AddImagePart(ImagePartType.Jpeg);
    using (MemoryStream stream = new MemoryStream())
    {
        image.Save(stream, ImageFormat.Jpeg);
        stream.Position = 0;
        imagePart.FeedData(stream);
    }
    blip.Embed = _mainDocumentPart.GetIdOfPart(imagePart);
