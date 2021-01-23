            var parentDirectory = Directory.GetParent(SelectedDocuments[0].FilePath);
            var savePath = parentDirectory + "\\MergedDocument.pdf";
            using (var fs = new FileStream(savePath, FileMode.Create))
            {
                using (var document = new Document())
                {
                    using (var pdfCopy = new PdfCopy(document, fs))
                    {
                        document.Open();
                        for (var i = 0; i < SelectedDocuments.Count; i++)
                        {
                            using (var pdfReader = new PdfReader(SelectedDocuments[i].FilePath))
                            {
                                for (var page = 0; page < pdfReader.NumberOfPages;)
                                {
                                    pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, ++page));
                                }
                            }
                        }
                    }
                }
            }
