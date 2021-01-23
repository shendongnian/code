    using (var existingFileStream = File.OpenRead(_pdfTemplatePath))
    using (var memoryStream = new MemoryStream())
    {
        // Open existing PDF  
        var pdfReader = new PdfReader(existingFileStream);
        // PdfStamper, which will create  
        var stamper = new PdfStamper(pdfReader, memoryStream);
                
        var form = stamper.AcroFields;
                
        form.SetField("Field_A", yourDataForA);
        form.SetField("Field_B", yourDataForB);
        form.SetField("Field_C", yourDataForC);
        stamper.FormFlattening = true;
        stamper.Close();
        pdfReader.Close();
        string cd = "inline";
        // And then send to the browser
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("content-disposition", 
            string.Format("{0};filename={1}.pdf", cd, string.IsNullOrEmpty(_theFilename)
                                                                         ? "documento"
                                                                         : _theFilename));
        HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
    }
