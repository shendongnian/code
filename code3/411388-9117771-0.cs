    string[] SplitHTML = fileName.Split('.');
    string NameNoExt = SplitHTML[0];
    string FileAsHtml = NameNoExt + ".html";
     
    //Word with the document
    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document _doc = wordApp.Documents.Open(uri);
    _doc.SaveAs2(FileAsHtml, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML);
    _doc.Close(false);
    wordApp.Quit();
    System.Runtime.InteropServices.Marshal.ReleaseComObject(_doc);
    browser.Navigate(FileAsHtml);
