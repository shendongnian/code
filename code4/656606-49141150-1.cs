    Private Sub dgvView_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.ColumnHeaderMouseClick
        With dgvView
            If .SelectionMode <> DataGridViewSelectionMode.ColumnHeaderSelect Then
                .SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect
                .Columns(e.ColumnIndex).Selected = True
            End If
        End With
    End Sub
    Private Sub dgvView_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.RowHeaderMouseClick
        With dgvView
            If .SelectionMode <> DataGridViewSelectionMode.RowHeaderSelect Then
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                .Rows(e.RowIndex).Selected = True
            End If
        End With
    End Sub
