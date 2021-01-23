    J2kImageData imageData = J2kImageData.FromImage("input.bmp");
    
    var options30x = new J2kEncodingOptions
    {
        Codec = J2kCodec.J2k,
        QualityMode = J2kQualityMode.CompressionRatio,
        QualityValues = new float[] { 30 }
    };
    imageData.Encode(@"output-30x.j2k", options30x);
