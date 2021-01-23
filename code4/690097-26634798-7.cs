    var resultStream = new MemoryStream();
    using (var zipArchive = new ZipArchive(resultStream, ZipArchiveMode.Create, true))
    {
        foreach (var doc in req)
        {
            var fileName = string.Format("Install.Rollback.{0}.v{1}.docx", doc.AppName, doc.Version);
            var xmlData = doc.GetXDocument();
            var fileStream = WriteWord.BuildFile(templatePath, xmlData);
            var docZipEntry = zipArchive.CreateEntry(fileName, CompressionLevel.Optimal);
            using (var entryStream = docZipEntry.Open())
            {
                fileStream.CopyTo(entryStream);
            }
        }
    }
    resultStream.Position = 0;
    // add the Response Header for downloading the file
    var cd = new ContentDisposition
        {
            FileName = string.Format(
                "{0}.{1}.{2}.{3}.Install.Rollback.Documents.zip",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (long)DateTime.Now.TimeOfDay.TotalSeconds),
            // always prompt the user for downloading, set to true if you want 
            // the browser to try to show the file inline
            Inline = false,
        };
    Response.AppendHeader("Content-Disposition", cd.ToString());
    // stuff the zip package into a FileStreamResult
    var fsr = new FileStreamResult(resultStream, MediaTypeNames.Application.Zip);    
    return fsr;
