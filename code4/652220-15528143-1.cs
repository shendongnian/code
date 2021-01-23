     private static void CombineAndSavePdf(string savePath, List<string> lstPdfFiles)
        {
            using (Stream outputPdfStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document();
                PdfSmartCopy copy = new PdfSmartCopy(document, outputPdfStream);
                document.Open();
                PdfReader reader;
                int totalPageCnt;
                PdfStamper stamper;
                string[] fieldNames;
                foreach (string file in lstPdfFiles)
                {
                    reader = new PdfReader(file);
                    totalPageCnt = reader.NumberOfPages;
                    for (int pageCnt = 0; pageCnt < totalPageCnt; )
                    {
                         //have to create a new reader for each page or PdfStamper will throw error
                        reader = new PdfReader(file);
                        stamper = new PdfStamper(reader, outputPdfStream);
                        fieldNames = new string[stamper.AcroFields.Fields.Keys.Count];
                        stamper.AcroFields.Fields.Keys.CopyTo(fieldNames, 0);
                        foreach (string name in fieldNames)
                        {
                            stamper.AcroFields.RenameField(name, name + "_file" + pageCnt.ToString());
                        }
                        copy.AddPage(copy.GetImportedPage(reader, ++pageCnt));                     
                    }
                    copy.FreeReader(reader);                    
                }
                document.Close();
            }
        }
