    var bitmap = new Bitmap(@"c:\Dokumente und Einstellungen\daniel.hilgarth\Desktop\Unbenannt.bmp");
     
    ImageCodecInfo jpgEncoder = ImageCodecInfo.GetImageEncoders().Single(x => x.FormatDescription == "JPEG");
    Encoder encoder2 = System.Drawing.Imaging.Encoder.Quality;
    EncoderParameters parameters = new System.Drawing.Imaging.EncoderParameters( 1 );
    EncoderParameter parameter = new EncoderParameter( encoder2, 50L );
    parameters.Param[0] = parameter;
     
    System.IO.Stream stream = new MemoryStream();
    bitmap.Save( stream, jpgEncoder, parameters );
    bitmap.Save(@"C:\Temp\TestJPEG.jpg", jpgEncoder, parameters);
     
    var bytes = ((MemoryStream)stream).ToArray();
    System.IO.Stream inputStream = new MemoryStream(bytes);
    Bitmap fromDisk = new Bitmap(@"C:\Temp\TestJPEG.jpg");
    Bitmap fromStream = new Bitmap(inputStream);
