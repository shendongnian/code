    //Create a copy of the original PDF file from source 
    //to the destination location
    File.Copy(formLocation, outputFileNameAndPath, true);
    //Open the newly created PDF file
    using (var pdfDoc = PdfSharp.Pdf.IO.PdfReader.Open(
                        outputFileNameAndPath, 
                        PdfSharp.Pdf.IO.PdfDocumentOpenMode.Modify))
    {
       //Get the fields from the PDF into which the data 
       //is supposed to be inserted
        var pdfFields = pdfDoc.AcroForm.Fields;
        //To allow appearance of the fields
        if (pdfDoc.AcroForm.Elements.ContainsKey("/NeedAppearances") == false)
        {
            pdfDoc.AcroForm.Elements.Add(
                "/NeedAppearances", 
                new PdfSharp.Pdf.PdfBoolean(true));
        }
        else
        {
            pdfDoc.AcroForm.Elements["/NeedAppearances"] = 
                new PdfSharp.Pdf.PdfBoolean(true);
        }
        //To set the readonly flags for fields to their original values
        bool flag = false;
        //Iterate through the fields from PDF
        for (int i = 0; i < pdfFields.Count(); i++)
        {
            try
            {
                //Get the current PDF field
                var pdfField = pdfFields[i];
                flag = pdfField.ReadOnly;
                        
                //Check if it is readonly and make it false
                if (pdfField.ReadOnly)
                {
                    pdfField.ReadOnly = false;
                }
                        
                pdfField.Value = new PdfSharp.Pdf.PdfString(
                                 fdfDataDictionary.Where(
                                 p => p.Key == pdfField.Name)
                                 .FirstOrDefault().Value);
                        
                //Set the Readonly flag back to the field
                pdfField.ReadOnly = flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ERROR_FILE_WRITE_FAILURE + ex.Message);
            }
        }
        //Save the PDF to the output destination
        pdfDoc.Save(outputFileNameAndPath);                
        pdfDoc.Close();
    }
