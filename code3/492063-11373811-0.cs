    private static void SettingFieltValue(Font font, IEnumerable<SalayDetailsForPdf> dataSalaryDetails, int selectedYear, string directoryOutPdf, string nameOutPdf, string pdfTemplatePath)
        {
        string pdfTemplate = pdfTemplatePath + @"\EmptyTemplateBankBlank_2012.pdf";
        string newFile = directoryOutPdf + nameOutPdf;
        var fs = new FileStream(newFile, FileMode.Create);
        var conc = new PdfConcatenate(fs, true);
        foreach (var data in dataSalaryDetails)
        {
            var reader = new PdfReader(pdfTemplate);
            using (var ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms))
                {
                    stamper.AcroFields.AddSubstitutionFont(font.BaseFont);
                    AcroFields form = stamper.AcroFields;
                    form.SetField("t1_name", data.NameHieroglyphic);
                    //Other field
                    stamper.FormFlattening = true;
                    stamper.Close();
                }
                reader = new PdfReader(ms.ToArray());
                ms.Close();                    
            }
            conc.AddPages(reader);
            reader.Close();
        }
        conc.Close();
    }
