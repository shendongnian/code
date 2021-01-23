    public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
    
                int pageN = writer.PageNumber;
                String text = "Page " + pageN + " of ";
                float len = bf.GetWidthPoint(text, 8);
    
                Rectangle pageSize = document.PageSize;
    
                cb.SetRGBColorFill(100, 100, 100);
    
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
    
                cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));
                
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, 
                    "Printed On " + PrintTime.ToString(), 
                    pageSize.GetRight(40), 
                    pageSize.GetBottom(30), 0);
                cb.EndText();
            }
