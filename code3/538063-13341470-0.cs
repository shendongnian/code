    string new_file_name = file_name;
    QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
    QrCode qrCode = new QrCode();
    qrEncoder.TryEncode(content, out qrCode);
    Renderer renderer = new Renderer(image_size, Brushes.Black, Brushes.White);
    MemoryStream ms = new MemoryStream();
    renderer.WriteToStream(qrCode.Matrix, ms, ImageFormat.Png);
    
    var imageTemp = new Bitmap(ms)
    var image = new Bitmap(imageTemp, new Size(new Point(200, 200)));
    image.Save(new_file_name + ".png", ImageFormat.Png);
