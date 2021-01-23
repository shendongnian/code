        private static byte[] RemoveTheLastPageWhichWasAddedForReordering(byte[] renderedBuffer)
        {
            var originalPdfReader = new PdfReader(renderedBuffer);
            using (var msCopy = new MemoryStream())
            {
                using (var docCopy = new Document())
                {
                    using (var copy = new PdfCopy(docCopy, msCopy))
                    {
                        docCopy.Open();
                        for (var pageNum = 1; pageNum <= originalPdfReader.NumberOfPages - 1; pageNum++)
                        {
                            copy.AddPage(copy.GetImportedPage(originalPdfReader, pageNum));
                        }
                        docCopy.Close();
                    }
                }
                return msCopy.ToArray();
            }
        }
