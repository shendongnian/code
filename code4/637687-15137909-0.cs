    private void ScanQRPdf(string imagePath)
    {
        var files = Directory.GetFiles ( path, "*.png", SearchOption.AllDirectories );
        
        QRCodeDecoder decoder = new QRCodeDecoder();
        
        StringBuilder sb = new StringBuilder();
        
        foreach (var item in files)
        {
            
                Bitmap b = new Bitmap(imagePath);
                try
                {
                    String decodedString = decoder.decode(new QRCodeBitmapImage(b));
                    
                    sb.AppendLine(decodedString);
                }
                catch (Exception ex)
                {
                }
            
        }
        
        rtbpdfData.Text = sb.ToString();
    }
