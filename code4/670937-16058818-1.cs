    Word._Application oWord;
    Word._Document oDoc;
    object oMissing = Type.Missing;
    oWord = new Word.Application();
    oWord.Visible = true;
    
    //Add Blank sheet to Word App
    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing); 
     
    oWord.Selection.TypeText("Write your text here");
