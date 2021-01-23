    // All calls to GS() must ensure that the returned stream gets closed.
    public Stream GS(string ID, PdfReader reader) 
    { 
        Stream newPdf = null; // This gets overwritten at the end 
                              // ... anyway, no need to create a
                              // ... new instance of MemoryStream()
        MemoryStream ms = new MemoryStream();
        PdfStamper formFiller = null;
        try 
        { 
            formFiller = new PdfStamper(reader, ms); 
            AcroFields formFields = formFiller.AcroFields; 
            formFields.SetField("ID", ID); 
     
            formFiller.FormFlattening = true; 
            formFiller.Writer.CloseStream = false; 
            newPdf = ms; 
        }
        catch
        {
            // Only close ms on an exception
            ms.Close();
            throw; // Rethrow original exception
        }
        finally
        {
            // Always ensure that formFiller gets closed
            formFiller.Close();
        }
        return newPdf; 
    } 
