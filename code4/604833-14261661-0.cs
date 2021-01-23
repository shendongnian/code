    Sub PRISM_BuildPropertyChanged_CursorAtDefaultAfterCtrlRE()
        DTE.ActiveDocument.Selection.LineDown(False, 2)
        DTE.ActiveDocument.Selection.WordLeft(True)
        DTE.ActiveDocument.Selection.Copy()
        DTE.ActiveDocument.Selection.LineDown(False, 3)
        DTE.ActiveDocument.Selection.EndOfLine()
        DTE.ActiveDocument.Selection.CharLeft()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "RaisePropertyChanged(() => this."
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.Text = ");"
        DTE.ActiveDocument.Selection.LineUp()
        DTE.ActiveDocument.Selection.StartOfLine(vsStartOfLineOptions.vsStartOfLineOptionsFirstText)
        DTE.ActiveDocument.Selection.CharRight(False, 4)
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.CharRight()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "if (value != "
        DTE.ActiveDocument.Selection.WordRight(True)
        DTE.ActiveDocument.Selection.Copy()
        DTE.ActiveDocument.Selection.CharLeft()
        DTE.ActiveDocument.Selection.Paste()
        DTE.ActiveDocument.Selection.DeleteLeft()
        DTE.ActiveDocument.Selection.Text = ")"
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "{"
        DTE.ActiveDocument.Selection.LineDown()
        DTE.ActiveDocument.Selection.EndOfLine()
        DTE.ActiveDocument.Selection.NewLine()
        DTE.ActiveDocument.Selection.Text = "}"
    End Sub
