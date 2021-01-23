    object oMissing = System.Reflection.Missing.Value;
    
    var oWord = new Microsoft.Office.Interop.Word.Application();
    oWord.Visible = false;
    var oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    
    var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
    oPara1.Range.Text = inputTextBox.Text;
    
    sentenceCountLabel.Text = oDoc.Sentences.Count.ToString();
    
    object oFalse = false;
    
    oDoc.Close(ref oFalse, ref oMissing, ref oMissing);
