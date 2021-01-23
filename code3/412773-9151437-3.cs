    object oMissing = System.Reflection.Missing.Value;
    
    var oWord = new Microsoft.Office.Interop.Word.Application();
    oWord.Visible = false;
    var oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    
    oDoc.Content.Text = inputTextBox.Text;
    
    //get just sentence count
    sentenceCountLabel.Text = oDoc.Sentences.Count.ToString();
    
    //get all statistics
    foreach (Microsoft.Office.Interop.Word.ReadabilityStatistic stat in oDoc.ReadabilityStatistics)
    {
        Console.WriteLine("{0}: {1}", stat.Name, stat.Value);
    }
    object oFalse = false;
    
    oDoc.Close(ref oFalse, ref oMissing, ref oMissing);
