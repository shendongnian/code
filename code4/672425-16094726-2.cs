    public void Download(string name)
            {
    //your logic. Sample code follows. You need to write your stream to the response.
                var filestream = System.IO.File.ReadAllBytes(@"path/sourcefilename.pdf");
                var stream = new MemoryStream(filestream);
                stream.WriteTo(Response.OutputStream);
                Response.AddHeader("Content-Disposition", "Attachment;filename=targetFileName.pdf");
                Response.ContentType = "application/pdf";
            }
