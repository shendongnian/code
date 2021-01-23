            var inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
            var output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
            //Bind a reader to our input file
            var reader = new PdfReader(inputFile);
            //Create our output file, nothing special here
            using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (Document doc = new Document(reader.GetPageSizeWithRotation(1))) {
                    //Use a PdfCopy to duplicate each page
                    using (PdfCopy copy = new PdfCopy(doc, fs)) {
                        doc.Open();
                        copy.SetLinearPageMode();
                        for (int i = 1; i <= reader.NumberOfPages; i++) {
                            copy.AddPage(copy.GetImportedPage(reader, i));
                        }
                        //Reorder pages
                        copy.ReorderPages(new int[] { 2, 1 });
                        doc.Close();
                    }
                }
            }
