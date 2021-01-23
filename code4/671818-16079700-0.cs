    Word._Application oWord;
    Word._Document oDoc;
    object oMissing = Type.Missing;
    oWord = new Word.Application();
    oWord.Visible = true;
    
    //Add Blank sheet to Word App
    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing); 
     
    oWord.Selection.TypeText("Write your text here");
    //FOrmatting your text
    oWord.Selection.Font.Size = 8;
    oWord.Selection.Font.Name = "Zurich BT";
    oWord.Selection.Font.Italic = 1
    oWord.Selection.Font.Bold = 1
    oDoc.Content.Application.ActiveWindow.ActivePane.View.SeekView = //Havent tested the  
                                                                 //header and footer part
    Word.WdSeekView.wdSeekCurrentPageFooter;
    oDoc.Content.Application.Selection.TypeText(“Martens”);
