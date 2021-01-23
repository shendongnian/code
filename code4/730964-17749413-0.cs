    Bitmap image = new Bitmap(imagePath);
    SdtElement controlBlock = doc.MainDocumentPart.HeaderParts.First().Header.Descendants<SdtElement>().Where
                                    (r => r.SdtProperties.GetFirstChild<Tag>().Val == tagName).SingleOrDefault();
     //find the Blip element of the content control
     Blip blip = controlBlock.Descendants<Blip>().FirstOrDefault();
     //add image and change embeded id
     ImagePart imagePart = doc.MainDocumentPart.AddImagePart(ImagePartType.Jpeg);
     using (MemoryStream stream = new MemoryStream())
     {
          image.Save(stream, ImageFormat.Jpeg);
          stream.Position = 0;
          imagePart.FeedData(stream);
     }
     blip.Embed = doc.MainDocumentPart.GetIdOfPart(imagePart);
