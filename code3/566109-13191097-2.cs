    using (PdfStamper stamper = new PdfStamper(new PdfReader(inputFile), File.Create(outputFile)))
    {
        TextField tf = new TextField(stamper.Writer, new iTextSharp.text.Rectangle(0, 0, 100, 300), "Vertical");
        stamper.AddAnnotation(tf.GetTextField(), 1);
        stamper.Close();
    }
