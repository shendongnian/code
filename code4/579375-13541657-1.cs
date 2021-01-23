    static void AddPushbuttonField(string inputFile, iTextSharp.text.Rectangle buttonPosition, string buttonName, string outputFile)
    {
        using (PdfStamper stamper = new PdfStamper(new PdfReader(inputFile), File.Create(outputFile)))
        {
            PushbuttonField buttonField = new PushbuttonField(stamper.Writer, buttonPosition, buttonName);
    
            stamper.AddAnnotation(buttonField.Field, 1);
            stamper.Close();
        }
    }
