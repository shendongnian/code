    public void Download(string name)
            {
    //your logic. Sample code follows. You need to write your stream to the response.
                var filestream = System.IO.File.ReadAllBytes(@"E:\Documents\sourcefilename.pdf");
                var stream = new MemoryStream(filestream);
                stream.Position = 0;
                stream.WriteTo(Response.OutputStream);
                Response.AddHeader("Content-Disposition", "Attachment;filename=targetFileName.pdf");
                Response.ContentType = "application/pdf";
            }
