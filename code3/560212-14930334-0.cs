    string[] validFileTypes = {"tiff"};
    string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
    bool isValidFile = false;
    if (!isValidFile)
    {
    Label.Text = "Invalid File. Please upload a File with extension " +
                           string.Join(",", validFileTypes);
    }
     else
        {
            string pdfpath = Server.MapPath("pdf");
            Document doc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Images.pdf", FileMode.Create));
            doc.Open();
       
            string savePath = Server.MapPath("images\\");
            if (FileUpload1.PostedFile.ContentLength != 0)
              {
                string path = savePath + FileUpload1.FileName;
                FileUpload1.SaveAs(path);
                iTextSharp.text.Image tiff= iTextSharp.text.Image.GetInstance(path);
                tiff.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                tiff.SetAbsolutePosition(0,0);
                PdfPTable table = new PdfPTable(1);
                table.AddCell(new PdfPCell(tiff));
                doc.Add(table);
              }
             doc.Close();
          }
