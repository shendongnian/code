        foreach (TableCell tabhead in gridview.HeaderRow.Cells)
        {
            PdfPCell pdfcell1 = new PdfPCell(new Phrase(tabhead.Text));
            pdftbale.AddCell(pdfcell1);
        }
        foreach (GridViewRow gd in gridview.Rows)
        {
            foreach (TableCell tab in gd.Cells)
            {
                PdfPCell pdfcell = new PdfPCell(new Phrase(tab.Text));
                pdftbale.AddCell(pdfcell);
            }
        }
        iTextSharp.text.Document pdfDocument = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
        PdfWriter.GetInstance(pdfDocument, new FileStream(Server.MapPath("~/pdf/" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf"), FileMode.Create));
        pdfDocument.Open();
        pdfDocument.Add(pdftbale);
        pdfDocument.Close();
