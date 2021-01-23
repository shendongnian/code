    public string ReadDocument(string fileName)
    {
        string value = string.Empty;
        try
        {
            theImage = codecs.Load(Enhance(fileName), 0, CodecsLoadByteOrder.BgrOrGray, 1, -1);
            for (int num = 1; num <= theImage.PageCount; num++)
            {
                BarcodeData dataArray = engine.Reader.ReadBarcode(theImage, LogicalRectangle.Empty, 0, null);
                qrCode = dataArray.Value;
                if (theImage.Page < theImage.PageCount)
                    theImage.Page++;
                value = dataArray.Value;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return value;
    }
