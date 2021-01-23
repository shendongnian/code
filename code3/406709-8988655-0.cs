    Sub Sort()
        Dim selection As EnvDTE.TextSelection = DTE.ActiveDocument.Selection
        If selection Is Nothing Or String.IsNullOrWhiteSpace(selection.Text) Then
            Exit Sub
        End If
        Dim lines As String() = selection.Text.Split(vbCrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        If lines.Length <= 1 Then Exit Sub
        lines = lines.OrderBy(Function(s As String) s, StringComparer.CurrentCulture).ToArray()
        DTE.UndoContext.Open("Sort Lines")
        Try
            selection.Insert(String.Join(vbCrLf, lines))
            selection.SmartFormat()
        Catch ex As Exception
            DTE.UndoContext.Close()
            DTE.StatusBar.Text = "Sort Lines complete"
        End Try
        selection.SmartFormat()
    End Sub
