    // All calls to GS() must ensure that the returned stream gets closed.
    public Stream GS(string ID, PdfReader reader) 
    { 
        MemoryStream newPdf = new MemoryStream();
        PdfStamper formFiller = null;
        try 
        { 
            formFiller = new PdfStamper(reader, newPdf); 
            AcroFields formFields = formFiller.AcroFields; 
            formFields.SetField("ID", ID); 
     
            formFiller.FormFlattening = true;
            //formFiller.Writer.CloseStream = false;
        }
        catch
        {
            // Only close newPdf on an exception
            newPdf.Close();
            throw; // Rethrow original exception
        }
        finally
        {
            // Always ensure that formFiller gets closed
            formFiller.Close();
        }
        return newPdf; 
    } 
