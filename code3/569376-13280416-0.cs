    using Word = Microsoft.Office.interop.Word; 
    //create a word app
    Word._Application  wordApp = new Word.Application();
    //add a page
    Word.Document doc = wordApp.Documents.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    //show word
    wordApp.Visible = true;
    //write some tex
    doc.Content.Text = "This is some content for the word document.\nI am going to want to place a page break HERE ";
    //inster a page break after the last word
    doc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
    //add some more text
    doc.Content.Text += "This line should be on the next page.";
    //clean up
    Marshal.FinalReleaseComObject(wordApp);
    Marshal.FinalReleaseComObject(doc);
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
