    using (var compressedFileStream = new MemoryStream()) {
        //Create an archive and store the stream in memory.
        using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Update, false))         {
         foreach (var caseAttachmentModel in caseAttachmentModels) {
            //Create a zip entry for each attachment
            var zipEntry = zipArchive.CreateEntry(caseAttachmentModel.Name);
            //Get the stream of the attachment
            using (var originalFileStream = new MemoryStream(caseAttachmentModel.Body)) {
                    using (var zipEntryStream = zipEntry.Open()) {
                        //Copy the attachment stream to the zip entry stream
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }
            }
        }
        sendOutZIP(compressedFileStream.ToArray(), "FileName.zip");
    }
    private void sendOutZIP(byte[] zippedFiles, string filename)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/x-compressed";
        Response.Charset = string.Empty;
        Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        Response.BinaryWrite(zippedFiles);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.End();
    }
