    targetMp3File = TagLib.File.Create(...);
      
    // define picture
    TagLib.Id3v2.AttachedPictureFrame pic = new TagLib.Id3v2.AttachedPictureFrame();
    pic.TextEncoding = TagLib.StringType.Latin1;
    pic.MimeType     = System.Net.Mime.MediaTypeNames.Image.Jpeg;
    pic.Type         = TagLib.PictureType.FrontCover;
    pic.Data         = TagLib.ByteVector.FromPath(...);
      
    // save picture to file
    targetMp3File.Tag.Pictures = new TagLib.IPicture[1] { pic };    
    targetMp3File.Save();
    
