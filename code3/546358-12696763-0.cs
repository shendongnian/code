    private void ThisAddIn_Startup(object sender, System.EventArgs a)
    {
      try
      {
        Word.Document doc = this.Application.ActiveDocument;
        if (String.IsNullOrWhiteSpace(doc.Path))
        {
          ProcessNewDocument(doc);
        }
        else
        {
          ProcessDocumentOpen(doc);
        }
      }
      catch (COMException e)
      {
        log.Debug("No document loaded with word.");
      }
      // These can be set anywhere in the method, because they are not fired for documents loaded when Word is initialized.
      ((MSWord.ApplicationEvents4_Event)this.Application).NewDocument +=
        new MSWord.ApplicationEvents4_NewDocumentEventHandler(Application_NewDocument);
      this.Application.DocumentOpen +=
        new MSWord.ApplicationEvents4_DocumentOpenEventHandler(Application_DocumentOpen);
    }
