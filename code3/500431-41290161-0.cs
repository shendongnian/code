    Private Sub DataGridViewJobsList_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJobsList.CellValueChanged
        If TypeOf TryCast(sender, DataGridView).CurrentCell Is DataGridViewCheckBoxCell Then
            Dim cell1 As DataGridViewCell
            cell1 = TryCast(sender, DataGridView).CurrentCell
            If cell1.Value = True Then
                For Each row As DataGridViewRow In TryCast(sender, DataGridView).Rows
                    If row.Index <> cell1.RowIndex AndAlso row.Cells(e.ColumnIndex).Value = "1" Then
                        row.Cells(e.ColumnIndex).Value = False
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub DataGridViewJobsList_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridViewJobsList.CurrentCellDirtyStateChanged
        If Me.DataGridViewJobsList.IsCurrentCellDirty Then
            DataGridViewJobsList.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
