     Microsoft.Office.Interop.Word.Application _wordApplication = Globals.ThisAddIn.Application;
           
    _wordApplication.ActiveWindow.ActivePane.View.ShowFieldCodes = true;
    try
    {
        _wordApplication.Selection.InsertFormula("");
        _wordApplication.Selection.MoveLeft(WdUnits.wdCharacter, 1);
        _wordApplication.Selection.TypeText("=");
        var field = _wordApplication.ActiveDocument.Fields.Add(_wordApplication.Selection.Range, Microsoft.Office.Interop.Word.WdFieldType.wdFieldEmpty, "PAGE", false);
        _wordApplication.Selection.MoveLeft(WdUnits.wdItem, 1);
        _wordApplication.Selection.TypeText("+1");
        field.Update();
    }
    finally
    {
        _wordApplication.ActiveWindow.ActivePane.View.ShowFieldCodes = false;
    }
