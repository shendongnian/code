    Private Sub CopyDataGridViewToClipboard(ByRef dgv As DataGridView)
        Try
            Dim s As String = ""
            Dim oCurrentCol As DataGridViewColumn    'Get header
            oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible)
            Do
                s &= oCurrentCol.HeaderText & Chr(Keys.Tab)
                oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, _
                   DataGridViewElementStates.Visible, DataGridViewElementStates.None)
            Loop Until oCurrentCol Is Nothing
            s = s.Substring(0, s.Length - 1)
            s &= Environment.NewLine    'Get rows
            For Each row As DataGridViewRow In dgv.Rows
                oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible)
                Do
                    If row.Cells(oCurrentCol.Index).Value IsNot Nothing Then
                        s &= row.Cells(oCurrentCol.Index).Value.ToString
                    End If
                    s &= Chr(Keys.Tab)
                    oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, _
                          DataGridViewElementStates.Visible, DataGridViewElementStates.None)
                Loop Until oCurrentCol Is Nothing
                s = s.Substring(0, s.Length - 1)
                s &= Environment.NewLine
            Next    'Put to clipboard
            Dim o As New DataObject
            o.SetText(s)
            Clipboard.SetDataObject(o, True)
        Catch ex As Exception
            ShowError(ex, Me)
        End Try
    End Sub
