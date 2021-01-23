    for (int i = 0; i < pdfPath.Length; i++)
	{
           PdfReader reader = new PdfReader(pdfPath[i]);
           PdfImportedPage page;
           PdfSmartCopy.PageStamp stamp;
           for (int ii = 0; ii < reader.NumberOfPages; ii++)
           {
                page = copy.GetImportedPage(reader, ii + 1);
                stamp = copy.CreatePageStamp(page);
                PdfContentByte cb = stamp.GetOverContent();
                cb.Rectangle(100, 100, 100, 100);
                cb.SetColorStroke(BaseColor.RED);
                cb.SetColorFill(BaseColor.RED);
                cb.FillStroke();
                stamp.AlterContents(); // don't forget to add this line
                copy.AddPage(page);                  
            }
	}
