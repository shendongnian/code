     PdfReader reader_FirstPdf = new PdfReader(pdf_of_FirstFile);
           
            
                for (int i = 1; i <= reader_FirstPdf.NumberOfPages; i++)
                {
     TextWithFont_SourcePdf Sourcepdf = new TextWithFont_SourcePdf();
    }
                    text_First_File = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader_FirstPdf, i, Sourcepdf);
    
    
                public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
                {
     int r = renderInfo.GetColorNonStroke().R;
                      int g = renderInfo.GetColorNonStroke().G;
                       int b = renderInfo.GetColorNonStroke().B;
    
    }
