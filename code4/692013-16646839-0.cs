    _wordApplication.ActiveWindow.ActivePane.View.ShowFieldCodes = true;
    try
    {
        _wordApplication.Selection.InsertFormula("=1");                      
        _wordApplication.Selection.MoveLeft(WdUnits.wdCharacter, 1);
        _wordApplication.Selection.TypeText("+");
        var field =_wordApplication.ActiveDocument.Fields.Add(_wordApplication.Selection.Range,   Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty, "PAGE", true);
        field.Update();
                        
    }           
    finally
    {
      _wordApplication.ActiveWindow.ActivePane.View.ShowFieldCodes = false;
    }
                  
  
