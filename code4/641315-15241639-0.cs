     private static void ChangeFont()
            {
    
    
                string strFile = @"E:\\xyz.pdf";
                string OutputFile = @"E:\\xyz1.pdf";
                PdfReader pdfReader = new PdfReader(strFile);
    
                //Get first page,Generally we get font information on first page,however we can loop throw pages e.g for(int i=0;i<=pdfReader.NumberOfPages;i++)
                    PdfDictionary cpage = pdfReader.GetPageN(1);
                    if (cpage == null)
                        return;
                    PdfDictionary dictFonts = cpage.GetAsDict(PdfName.RESOURCES).GetAsDict(PdfName.FONT);
                    if (dictFonts != null)
                    {
                        foreach (var font in dictFonts)
                        {
                            var dictFontInfo = dictFonts.GetAsDict(font.Key);
    
                            if (dictFontInfo != null)
                            {
                                foreach (var f in dictFontInfo)
                                {
                                    //Get the font name-optional code
                                    var baseFont = dictFontInfo.Get(PdfName.BASEFONT);
                                    string strFontName = System.Text.Encoding.ASCII.GetString(baseFont.GetBytes(), 0,
                                                                                              baseFont.Length);
                                    //
    
    
                                    //Remove the current font
                                    dictFontInfo.Remove(PdfName.BASEFONT);
                                    //Set new font eg. Braille, Areal etc
                                    dictFontInfo.Put(PdfName.BASEFONT, new PdfString("Braille"));
                                    break;
    
                                }
                            }
    
    
                        }
     
                }
    
                //Now create a new document with updated font
                using (FileStream FS = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document Doc = new Document())
                    {
                        using (PdfCopy writer = new PdfCopy(Doc, FS))
                        {
                            Doc.Open();
                            for (int j = 1; j <= pdfReader.NumberOfPages; j++)
                            {
                                writer.AddPage(writer.GetImportedPage(pdfReader, j));
                            }
                            Doc.Close();
                        }
                    }
                }
                pdfReader.Close();
    
            } 
