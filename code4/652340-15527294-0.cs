    var fileName = "TestDoc.docx";
    Object oMissing = System.Reflection.Missing.Value;
    var oTemplatePath = @"C:\Documents\wrkDocuments\" + fileName;
    var wordApp = new Word.Application();
    var originalDoc = wordApp.Documents.Open(@oTemplatePath);
    
    originalDoc.ActiveWindow.Selection.WholeStory();
    originalDoc.ActiveWindow.Selection.Copy();
       
    var newDocument = new Word.Document();
    newDocument.ActiveWindow.Selection.Paste();
    newDocument.SaveAs(@"C:\Users\Documents\wrkDocuments\TestDoc2.docx");
    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(originalDoc);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(newDocument);
    GC.Collect();
