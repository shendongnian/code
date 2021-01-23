    public Stream GS(string ID, PdfReader reader)
    {
        PdfStamper formFiller = new PdfStamper(reader, ms);
        AcroFields formFields = formFiller.AcroFields;
        formFields.SetField("ID", ID);
        formFiller.FormFlattening = true;
        formFiller.Writer.CloseStream = false;
        formFiller.Close();
        return ms;
    }
