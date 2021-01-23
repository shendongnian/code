        string destFile = Server.MapPath("~/Letters/sample.docx");
        object fileName = destFile; 
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
        Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(fileName, ReadOnly: false, Visible: false);
        object Unknown = Type.Missing;
        aDoc.Activate();
        try
        {
         //Replace any text inside the word document
         FindAndReplace(wordApp, "[Date]", DateTime.Now.ToString("MMMM dd, yyyy"));
        }
