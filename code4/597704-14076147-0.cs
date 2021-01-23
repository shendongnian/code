    // Given a monochrome bitmap file, one can read
    // information about that bitmap from the header
    // information in the file.  This information includes
    // bitmap height, width, bitsPerPixel, etc.  It is required
    // that a developer understands the basic bitmap format and
    // how to extract the following data in order to proceed.
    // A simple search online for 'bitmap format' should yield
    // all the needed information.  Here, for our example, we simply
    // declare what the bitmap information is, since we are working
    // with a known sample file.
     
    string bitmapFilePath = @"test.bmp";  // file is attached to this support article
    byte[] bitmapFileData = System.IO.File.ReadAllBytes(bitmapFilePath);
    int fileSize = bitmapFileData.Length;
     
    // The following is known about test.bmp.  It is up to the developer
    // to determine this information for bitmaps besides the given test.bmp.
    int bitmapDataOffset = 62;
    int width = 255;
    int height = 255;
    int bitsPerPixel = 1; // Monochrome image required!
    int bitmapDataLength = 8160;
    double widthInBytes = Math.Ceiling(width / 8.0);
     
    // Copy over the actual bitmap data from the bitmap file.
    // This represents the bitmap data without the header information.
    byte[] bitmap = new byte[bitmapDataLength];
    Buffer.BlockCopy(bitmapFileData, bitmapDataOffset, bitmap, 0, bitmapDataLength);
     
    // Invert bitmap colors
    for (int i = 0; i < bitmapDataLength; i++)
    {
        bitmap[i] ^= 0xFF;
    }
     
    // Create ASCII ZPL string of hexadecimal bitmap data
    string ZPLImageDataString = BitConverter.ToString(bitmap);
    ZPLImageDataString = ZPLImageDataString.Replace("-", string.Empty);
     
    // Create ZPL command to print image
    string[] ZPLCommand = new string[4];
     
    ZPLCommand[0] = "^XA";
    ZPLCommand[1] = "^FO20,20";
    ZPLCommand[2] =
        "^GFA, " +
        bitmapDataLength.ToString() + "," +
        bitmapDataLength.ToString() + "," +
        widthInBytes.ToString() + "," +
        ZPLImageDataString;
     
    ZPLCommand[3] = "^XZ";
     
    // Connect to printer
    string ipAddress = "10.3.14.42";
    int port = 9100;
    System.Net.Sockets.TcpClient client =
        new System.Net.Sockets.TcpClient();
    client.Connect(ipAddress, port);
    System.Net.Sockets.NetworkStream stream = client.GetStream();
     
    // Send command strings to printer
    foreach (string commandLine in ZPLCommand)
    {
        stream.Write(ASCIIEncoding.ASCII.GetBytes(commandLine), 0, commandLine.Length);
        stream.Flush();
    }
     
    // Close connections
    stream.Close();
    client.Close();
