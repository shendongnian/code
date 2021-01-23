        System.Drawing.Bitmap myImg = new System.Drawing.Bitmap(FileName);
        Dictionary<DecodeOptions, object> decodingOptions = new Dictionary<DecodeOptions, object>();
        List<BarcodeFormat> possibleFormats = new List<BarcodeFormat>();
        possibleFormats.Add(BarcodeFormat.QRCode);                              
        decodingOptions.Add(DecodeOptions.TryHarder, true);
        decodingOptions.Add(DecodeOptions.PossibleFormats, possibleFormats);
        Result decodedResult = decoder.Decode(myImg, decodingOptions);
         if (decodedResult != null)
           {
              //.. success
           }
