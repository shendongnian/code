    Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
    ((Outlook.InspectorEvents_10_Event)inspector).Activate += () =>
    {   // validation to ensure we are using Word Editor
    	if (inspector.EditorType == Outlook.OlEditorType.olEditorWord && inspector.IsWordMail())
    	{
    		Word.Document wordDoc = inspector.WordEditor as Word.Document;
    		if (wordDoc != null)
    		{
    			var bookmarks = wordDoc.Bookmarks;
    			foreach (Word.Bookmark item in bookmarks)
    			{
    				string name = item.Name; // bookmark name
    				Word.Range bookmarkRange = item.Range; // bookmark range
    				string bookmarkText = bookmarkRange.Text; // bookmark text
    				item.Select(); // triggers bookmark selection
    			}
    		}
    	}
    };
