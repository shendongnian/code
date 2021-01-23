        Word.Application WordApp = new Word.Application();
        Word.Document BaseDoc = default(Word.Document);
        Word.Document DestDoc = default(Word.Document);
        int intNumberOfPages = 0;
        string intNumberOfChars = null;    
        int intPage = 0;
       
        //Word Constants
         const var wdGoToPage = 1;
        const var wdStory = 6;
         const var wdExtend = 1;
         const var wdCharacter = 1;
        
         //Show WordApp
         WordApp.ShowMe();
        
        //Load Base Document
         BaseDoc = WordApp.Documents.Open(Filename);
         BaseDoc.Repaginate();
        
        //Loop through pages
       intNumberOfPages = BaseDoc.BuiltInDocumentProperties("Number of Pages").value;
         intNumberOfChars = BaseDoc.BuiltInDocumentProperties("Number of Characters").value;
       
         for (intPage = 1; intPage <= intNumberOfPages; intPage++) {
             if (intPage == intNumberOfPages) {
                 WordApp.Selection.EndKey(wdStory);         }
             else {
                WordApp.Selection.GoTo(wdGoToPage, 2);
                Application.DoEvents();
                
                 WordApp.Selection.MoveLeft(Unit = wdCharacter, Count = 1);
             }
            
           Application.DoEvents();
            
             WordApp.Selection.HomeKey(wdStory, wdExtend);
            Application.DoEvents();
                     WordApp.Selection.Copy();
             Application.DoEvents();        
            //Create New Document
            DestDoc = WordApp.Documents.Add;
            DestDoc.Activate();
            WordApp.Selection.Paste();
            DestDoc.SaveAs(NewFileName + intPage.ToString + ".doc");
            DestDoc.Close();
            DestDoc = null;
          
             WordApp.Selection.GoTo(wdGoToPage, 2);
             Application.DoEvents();
                     WordApp.Selection.HomeKey(wdStory, wdExtend);
            Application.DoEvents();
           
            WordApp.Selection.Delete();
            Application.DoEvents();
        }
        
         BaseDoc.Close(false);
         BaseDoc = null;
       
        WordApp.Quit();
         WordApp = null;
