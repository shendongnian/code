    Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
    Object oMissing = System.Reflection.Missing.Value;
    
    oWord.Visible = true;
    
    oWord.Activate(); 
    
    oWord.Dialogs[WdWordDialog.wdDialogFileNew].Show(oMissing);
