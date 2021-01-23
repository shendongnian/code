    /// <summary>
    /// Merges pdf files from a byte list
    /// </summary>
    /// <param name="files">list of files to merge</param>
    /// <returns>memory stream containing combined pdf</returns>
    public MemoryStream MergePdfForms(List<byte[]> files)
    {
        if (files.Count > 1)
        {
            string[] names;
            PdfStamper stamper;
            MemoryStream msTemp = null;
            PdfReader pdfTemplate = null;
            PdfReader pdfFile;
            Document doc;
            PdfWriter pCopy;
            MemoryStream msOutput = new MemoryStream();
    
            pdfFile = new PdfReader(files[0]);
    
            doc = new Document();
            pCopy = new PdfSmartCopy(doc, msOutput);
            pCopy.PdfVersion = PdfWriter.VERSION_1_7;
    
            doc.Open();
    
            for (int k = 0; k < files.Count; k++)
            {
                for (int i = 1; i < pdfFile.NumberOfPages + 1; i++)
                {
                    msTemp = new MemoryStream();
                    pdfTemplate = new PdfReader(files[k]);
    
                    stamper = new PdfStamper(pdfTemplate, msTemp);
    
                    names = new string[stamper.AcroFields.Fields.Keys.Count];
                    stamper.AcroFields.Fields.Keys.CopyTo(names, 0);
                    foreach (string name in names)
                    {
                        stamper.AcroFields.RenameField(name, name + "_file" + k.ToString());
                    }
    
                    stamper.Close();
                    pdfFile = new PdfReader(msTemp.ToArray());
                    ((PdfSmartCopy)pCopy).AddPage(pCopy.GetImportedPage(pdfFile, i));
                    pCopy.FreeReader(pdfFile);
                }
            }
    
            pdfFile.Close();
            pCopy.Close();
            doc.Close();
    
            return msOutput;
        }
        else if (files.Count == 1)
        {
            return new MemoryStream(files[0]);
        }
    
        return null;
    }
