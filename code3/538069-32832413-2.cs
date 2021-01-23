    private string gen_qr_file(string file_name, string content, int image_size)
    {
        string new_file_name = file_name;
        QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
        QrCode qrCode = new QrCode();
        qrEncoder.TryEncode(content, out qrCode);
    
        GraphicsRenderer renderer = new GraphicsRenderer(
            new FixedCodeSize(400, QuietZoneModules.Zero), 
            Brushes.Black, 
            Brushes.White);
        MemoryStream ms = new MemoryStream();
        renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
        var imageTemp = new Bitmap(ms);
        var image = new Bitmap(imageTemp, new Size(new Point(200, 200)));
        image.Save(new_file_name, ImageFormat.Png);
    
        return new_file_name;
    }
