    this.Application.DocumentBeforeClose += new Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(Application_DocumentBeforeClose);
    
    Application_DocumentBeforeClose(Interop.Word.Document document, ref bool Cancel)
    {
      // Documents is a list of the active Tools.Word.Document objects.
      if (this.Documents.ContainsKey(document.FullName))
      {
        // I set the tag to true to indicate I want to cancel.
        this.Document[document.FullName].Tag = true;
      }
    }
    public MyDocument() 
    {
      // Tools.Office.Document object
      doc.BeforeClose += new CancelEventHandler(WordDocument_BeforeClose);
    }
    private void WordDocument_BeforeClose(object sender, CancelEventArgs e)
    {
      Tools.Word.Document doc = sender as Tools.Word.Document;
      // This is where I now check the tag I set.
      bool? cancel = doc.Tag as bool?;
      if (cancel == true)
      {
        e.Cancel = true;
      }
    }
