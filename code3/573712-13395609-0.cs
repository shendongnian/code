    public string ConvertToString(Image image)
    {
        // First Convert image to byte array.
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
    
            byteArray = stream.ToArray();
        }
        // Convert byte[] to Base64 String
        string base64String = Convert.ToBase64String(byteArray);
        return base64String;  
    }
    
    
