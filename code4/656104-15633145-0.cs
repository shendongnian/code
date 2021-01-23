    try
    {
        // get image from object
        byte[] _ImageData = new byte[0];
        _ImageData = (byte[])_SqlRetVal;
        System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream(_ImageData);
        _Image = System.Drawing.Image.FromStream(_MemoryStream);
    }
    catch (Exception _Exception)
    {
        // Error occurred while trying to create image
        // send error message to console (change below line to customize error handling)
        Console.WriteLine(_Exception.Message);
        return null;
    }
