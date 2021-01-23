    Sub InsertMySnippet()
        DTE.ActiveDocument.Selection.Text = "mySnippetShortcut"
        DTE.ExecuteCommand("Edit.InsertTab")
        Dim selection As TextSelection = DTE.ActiveDocument.Selection
        selection.Insert(GetNamespace())
        DTE.ExecuteCommand("Edit.InsertTab")
    End Sub
