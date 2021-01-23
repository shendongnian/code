    Private WithEvents txtNumeric As New DataGridViewTextBoxEditingControl
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
    txtNumeric = CType(e.Control, DataGridViewTextBoxEditingControl)
    End Sub
    Private Sub txtNumeric_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeric.KeyPress
        If (DataGridView1.CurrentCell.ColumnIndex > 0) Then
            If (Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = ".") Then
                e.Handled = True
            Else
                'only allow one decimal point
                If (e.KeyChar = "." And txtNumeric.Text.Contains(".")) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
