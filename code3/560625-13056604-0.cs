    System.Drawing.Bitmap myImg = new System.Drawing.Bitmap(FileName);
    Dictionary<DecodeOptions, object> decodingOptions = new Dictionary<DecodeOptions, object>();
    List<BarcodeFormat> possibleFormats = new List<BarcodeFormat>(10);
        
                            possibleFormats.Add(BarcodeFormat.DataMatrix);
                            possibleFormats.Add(BarcodeFormat.QRCode);
                            possibleFormats.Add(BarcodeFormat.PDF417);
                            possibleFormats.Add(BarcodeFormat.Aztec);
                            possibleFormats.Add(BarcodeFormat.UPCE);
                            possibleFormats.Add(BarcodeFormat.UPCA);
                            possibleFormats.Add(BarcodeFormat.Code128);
                            possibleFormats.Add(BarcodeFormat.Code39);
                            possibleFormats.Add(BarcodeFormat.ITF14);
                            possibleFormats.Add(BarcodeFormat.EAN8);
                            possibleFormats.Add(BarcodeFormat.EAN13);
                            possibleFormats.Add(BarcodeFormat.RSS14);
                            possibleFormats.Add(BarcodeFormat.RSSExpanded);
                            possibleFormats.Add(BarcodeFormat.Codabar);
                            possibleFormats.Add(BarcodeFormat.MaxiCode);
        
     decodingOptions.Add(DecodeOptions.TryHarder, true);
     decodingOptions.Add(DecodeOptions.PossibleFormats, possibleFormats);
    Result decodedResult = decoder.Decode(myImg, decodingOptions);
            
              if (decodedResult != null)
                            {
                              //.. success
                            }
