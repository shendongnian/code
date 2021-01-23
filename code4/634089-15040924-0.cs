    public void ExportToPdf(DataTable ExDataTable) //Datatable 
      {
        //Here set page size as A4
    
        Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
    
      try
       {
          PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
          pdfDoc.Open();
    
           //Set Font Properties for PDF File
           Font fnt = FontFactory.GetFont("Times New Roman", 12);
           DataTable dt = ExDataTable;
    
            if (dt != null)
            {
    
                PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                PdfPCell PdfPCell = null;
    
                //Here we create PDF file tables
    
                for (int rows = 0; rows < dt.Rows.Count; rows++)
                {
                    if (rows == 0)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Columns[column].ColumnName.ToString(), fnt)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }
                    for (int column = 0; column < dt.Columns.Count; column++)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), fnt)));
                        PdfTable.AddCell(PdfPCell);
                    }
                }
    
                // Finally Add pdf table to the document 
                pdfDoc.Add(PdfTable);
            }
    
            pdfDoc.Close();
    
            Response.ContentType = "application/pdf";
    
            //Set default file Name as current datetime
            Response.AddHeader("content-disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMdd") + ".pdf");
    
            System.Web.HttpContext.Current.Response.Write(pdfDoc);
    
            Response.Flush();
            Response.End();
    
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }  
