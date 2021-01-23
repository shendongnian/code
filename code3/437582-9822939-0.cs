    Private Sub DataGridView1_UserDeletingRow( _
           ByVal sender As Object, _
           ByVal e As System.Windows.Forms. _
           DataGridViewRowCancelEventArgs) _
           Handles DataGridView1.UserDeletingRow
            If (Not e.Row.IsNewRow) Then
                Dim response As DialogResult = _
                MessageBox.Show( _
                "Are you sure you want to delete this row?", _
                "Delete row?", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question, _
                MessageBoxDefaultButton.Button2)
                If (response = DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub
