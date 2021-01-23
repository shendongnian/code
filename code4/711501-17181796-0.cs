    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DGV.CurrentCell = DGV.Rows(e.RowIndex).Cells(e.ColumnIndex)
            
            CMS.Show(DGV, DGV.PointToClient(Windows.Forms.Cursor.Position))
        End If
    End Sub
