                Word._Application oWord;
                Word._Document oDoc;
                object oMissing = Type.Missing;
                oWord = new Word.Application();
                oWord.Visible = true;
                
                
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing); //Add Blank sheet to Word App
                 
                 oWord.Selection.TypeText("Write your text here");
