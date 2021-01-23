    protected void btnPDF_Click(object sender, EventArgs e) {
        //Byte array that will eventually hold our PDF, currently empty
        Byte[] bytes;
        //Instead of a FileStream we'll use a MemoryStream
        using (var MS = new System.IO.MemoryStream()) {
            //Standard PDF setup, iText doesn't care what type of stream we're using
            var doc = new iTextSharp.text.Document();
            var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, MS);
            doc.Open();
            doc.Add(new iTextSharp.text.Paragraph("Hello world"));
            doc.Close();
            //Grab the raw bytes from the MemoryStream
            bytes = MS.ToArray();
        }
        
        //At this point all iText work is done and we're only dealing with raw ASP.Net parts
        //Clear the current response buffer
        Response.Clear();
        //Instead of a normal text/html header tell the browser that we've got a PDF
        Response.ContentType = "application/pdf";
        //Tell the browser that you want the file downloaded (ideally) and give it a pretty filename
        Response.AddHeader("content-disposition", "attachment;filename=MySampleFile.pdf");
        //Write our bytes to the stream
        Response.BinaryWrite(bytes);
        //Close the stream (otherwise ASP.Net might continue to write stuff on our behalf)
        Response.End();
    }
