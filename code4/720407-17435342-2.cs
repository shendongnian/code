    List<string> myValues=new List<string>();
    for (int num = 1; num <= theImage.PageCount; num++)
            {
                BarcodeData dataArray = engine.Reader.ReadBarcode(theImage, LogicalRectangle.Empty, 0, null);
                qrCode = dataArray.Value;
            if (theImage.Page < theImage.PageCount)
                theImage.Page++;
            myValues.Add(dataArray.Value);
        }
