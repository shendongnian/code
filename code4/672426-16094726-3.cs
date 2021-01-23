        public FileStreamResult Download(string name)
        {
            var filestream = System.IO.File.ReadAllBytes(@"path/sourcefilename.pdf");
            var stream = new MemoryStream(filestream);
            
            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = "targetfilename.pdf"
            };
        }
