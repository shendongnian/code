    Public Sub PopupEditorMethod(ByVal sender As Object, ByVal e As ExecuteCommandEventArgs(Of OurObject))
        Dim row = CType(e.OriginalSource, Xceed.Wpf.DataGrid.DataRow)
        row.EndEdit()
        'popup implementation
    End Sub
