        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
        var oMissing = System.Reflection.Missing.Value;
        // grab all the filenames from your directory (*.*) and filter them with linq
        var wordDocumentFilenames = Directory.GetFiles(@"C:\TestFilestore\", "*.*").
                                    Where(file => 
                                        file.ToLower().EndsWith("doc") ||
                                        file.ToLower().EndsWith("docx")).  // extend the list to your needs
                                        ToList(); 
        foreach (var wordDocumentFilename in wordDocumentFilenames)
        {
            Microsoft.Office.Interop.Word.Document wordDocument = word.Documents.Open(
                wordDocumentFilename, 
                ref oMissing,
                /* supply the rest of the parameters */);
        }
