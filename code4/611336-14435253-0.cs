    using Word = Microsoft.Office.Interop.Word;
    
    //...
    
    Word.Application app = new Word.Application();
    Word.Document myDoc = app.Documents.Add(pathToMyDoc);
    
    for(int n = 0; n < myDoc.Characters.Count; ++n)
    {
      myDoc.Characters[n].Text = LookupReplacement(myDoc.Characters[n].Text);
    }
