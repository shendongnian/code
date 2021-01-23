    PdfPTable footerTbl = new PdfPTable(1);
    
            //set the width of the table to be the same as the document
            footerTbl.TotalWidth = document.PageSize.Width;
    
            //Center the table on the page
            footerTbl.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
    
            //Create a paragraph that contains the footer text
            Paragraph para = new Paragraph(String.Format("Urdu Word Processor                 Date : {0:dd/MMM/yyyy}                  Page Number : {1}", DateTime.Now, writer.PageNumber), footer);
    
            //add a carriage return
            //para.Add(Environment.NewLine);
            //para.Add("Some more footer text");
    
            //create a cell instance to hold the text
            PdfPCell cell = new PdfPCell(para);
    
            //set cell border to 0
            cell.Border = 0;
    
            //add some padding to bring away from the edge
            cell.PaddingLeft = 120.0f;
    
            //add cell to table
            footerTbl.AddCell(cell);
    
            //create new instance of Paragraph for 2nd cell text
            //para = new Paragraph("Some text for the second cell", footer);
    
            //create new instance of cell to hold the text
            //cell = new PdfPCell(para);
    
            //align the text to the right of the cell
            //cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            //set border to 0
            //cell.Border = 0;
    
            // add some padding to take away from the edge of the page
            //cell.PaddingRight = 5;
    
            //add the cell to the table
            //footerTbl.AddCell(cell);
    
            //write the rows out to the PDF output stream.
            footerTbl.WriteSelectedRows(0, -1, 0, (document.BottomMargin + 790), writer.DirectContent);
