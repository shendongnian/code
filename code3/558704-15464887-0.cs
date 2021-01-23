    Private Sub GridView_CellMouseMove(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridView.CellMouseMove
        Select Case GridView.Columns(e.ColumnIndex).Name
            Case "Ad_Edit", "Size_Caption", "Demo_Code"
                GridView.EditMode = DataGridViewEditMode.EditOnEnter
            Case Else
                GridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        End Select
    End Sub
