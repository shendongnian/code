        public ActionResult Index()
        {
            string fileName = "test.pdf";
            string fileName1 = "test.vsix";
            string fileNameZip = "Export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip";
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\test\test.pdf");
            byte[] fileBytes1 = System.IO.File.ReadAllBytes(@"C:\test\test.vsix");
            byte[] compressedBytes;
            using (var outStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                {
                    var fileInArchive = archive.CreateEntry(fileName, CompressionLevel.Optimal);
                    using (var entryStream = fileInArchive.Open())
                    using (var fileToCompressStream = new MemoryStream(fileBytes))
                    {
                        fileToCompressStream.CopyTo(entryStream);
                    }
                    var fileInArchive1 = archive.CreateEntry(fileName1, CompressionLevel.Optimal);
                    using (var entryStream = fileInArchive1.Open())
                    using (var fileToCompressStream = new MemoryStream(fileBytes1))
                    {
                        fileToCompressStream.CopyTo(entryStream);
                    }
                }
                compressedBytes = outStream.ToArray();
            }
            return File(compressedBytes, "application/zip", fileNameZip);
        }
