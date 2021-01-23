      //I don't know what you're doing with this variable so I'm just setting it to something
      int nPaginasPDF = 10;
      //I can't write to my C: drive so I'm saving to the desktop
      string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      //Set the default file name
      saveFileDialog1.FileName = "name.pdf";
      //If the user presses "OK"
      if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
          //Create a bitmap and save it to disk
          using (Bitmap bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height)) {
              panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
              //Path.Combine is a safer way to build file pathes
              bitmap.Save(System.IO.Path.Combine(saveFolder, nPaginasPDF + ".bmp"), ImageFormat.Bmp);
          }
          //Create a new file stream instance with some locks for safety
          using (var fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)) {
              //Create our iTextSharp document
              using (var doc = new Document()) {
                  //Bind a PdfWriter to the Document and FileStream
                  using (var writer = PdfWriter.GetInstance(doc, fs)) {
                      //Open the document for writing
                      doc.Open();
                      //Get an instance of our image
                      iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(System.IO.Path.Combine(saveFolder, nPaginasPDF + ".bmp"));
                      //Sacle it
                      image1.ScalePercent(23f);
                      //Add a new page
                      doc.NewPage();
                      //Add our image to the document
                      doc.Add(image1);
                      //Close our document for writing
                      doc.Close();
                  }
              }
          }
      }
