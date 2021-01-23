    Public Class MyGrid
        Inherits Windows.Forms.DataGridView
        Private Sub MyGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                           Handles Me.CurrentCellDirtyStateChanged
            If Me.IsCurrentCellDirty AndAlso Not Me.CurrentCell Is Nothing Then
               If TypeOf Me.Columns(Me.CurrentCell.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                  Me.CommitEdit(DataGridViewDataErrorContexts.Commit) 'imediate commit, not only on focus changed
               End If
            End If
        End Sub
        Private Sub MyGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) 
                           Handles Me.CellValueChanged
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
               Dim Checked As Boolean = False
               If TypeOf Me.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
                  'avoid erros
                  Checked = Me.CellChecked(e.RowIndex, e.ColumnIndex)
               End If
               RaiseEvent Change(e.RowIndex, e.ColumnIndex, Checked)
            End If
        End Sub
    
    End Class
