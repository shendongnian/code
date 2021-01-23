    private byte[] createPDF(string html) {
        //Basic PDF setup
        using (var msOutput = new MemoryStream()) {
            using (var document = new Document(PageSize.A4, 30, 30, 30, 30)) {
                using (var writer = PdfWriter.GetInstance(document, msOutput)) {
                    //Open our document for writing
                    document.Open();
                    //Bind a reader to our text
                    using (TextReader reader = new StringReader(html)) {
                        //Parse the HTML and write it to the document
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, reader);
                    }
                    //Close the main document
                    document.Close();
                }
                //Return our raw bytes
                return msOutput.ToArray();
            }
        }
    }
