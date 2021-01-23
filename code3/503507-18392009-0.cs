    // Instantiate a TNEF Encoding object to process the byte array "tnefEncoddedBytes".
    TnefEncoding tnefEncoding = new TnefEncoding(tnefEncodedBytes);
 
    // Loop through the TNEF-encoded attachments, outputting their names, content types, and sizes.
    foreach (MimePart mimePart in tnefEncoding.MimeAttachments)
    {
        Console.WriteLine("MIME Part Name: " + mimePart.Name);
        Console.WriteLine("MIME Part Content Type: " + mimePart.ContentType);
        Console.WriteLine("MIME Part Size: " + mimePart.BodyBytes.Length);
    }
