    Private Sub dgvInvoices_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvInvoices.CellValidating
        dgvInvoices.Rows(e.RowIndex).Cells(3).ErrorText = ""
        Dim newInteger As Integer
        dgvInvoices.ShowCellErrors = True
        If Not Double.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger < 0 Then
            e.Cancel = True
            dgvInvoices.Rows(e.RowIndex).Cells(3).ErrorText = "the value must be a non-negative integer"
            MsgBox("Ensure the value is a numeric value.", vbExclamation, "Error")
        End If
    End Sub
