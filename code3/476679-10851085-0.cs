    //Image part
    //We will dump the bytes from the memory stream to the variable below later
    byte[] bytes;
    using (MemoryStream ms = new MemoryStream()){
      Document doc = new Document(PageSize.LETTER);
      PdfWriter writer = PdfWriter.GetInstance(doc, ms);
      doc.Open();
      //foreach (string filenm in Images)
      //...
      doc.Close();
      //Dump the bytes, make sure to use ToArray() and not GetBuffer()
      bytes = ms.ToArray();
    }
    
    //Watermark part
    //Read from our bytes
    PdfReader pdfReader = new PdfReader(bytes);
    FileStream stream = new FileStream(txtpath.Text + pdfname,FileMode.Open);
    //...
