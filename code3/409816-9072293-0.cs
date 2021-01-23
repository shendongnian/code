    string pdfpath = Server.MapPath("PDFs");
    string imagepath = Server.MapPath("Images");
    Document doc = new Document();
    try
    {
      PdfWriter.GetInstance(doc, new FileStream(pdfpath + "/Images.pdf", FileMode.Create));
      doc.Open();
     
      doc.Add(new Paragraph("GIF"));
      Image gif;
      if (chkBoxExample.Checked)
      { 
          gif = Image.GetInstance(imagepath + "/checked.gif");
      }
      else
      {
          gif = Image.GetInstance(imagepath + "/unchecked.gif");
      }
      doc.Add(gif);
    }
    finally
    {
      doc.Close();
    }
