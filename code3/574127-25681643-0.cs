    // Method to save album art
    TagLib.Picture pic = new TagLib.Picture();
    pic.Type = TagLib.PictureType.FrontCover;
    pic.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
    pic.Description = "Cover";
    MemoryStream ms = new MemoryStream();
    currentImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // <-- Error doesn't occur anymore
    ms.Position = 0;
    pic.Data = TagLib.ByteVector.FromStream(ms);
    f.Tag.Pictures = new TagLib.IPicture[1] { pic };
    f.save();
    ms.Close();
