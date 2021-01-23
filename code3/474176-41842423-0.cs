        Private Sub DatagridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DatagridView.RowsAdded
        With DirectCast(sender, DataGridView)
            If .Item(yourColumnIndex, e.RowIndex).Value Is "yourValue" Then
                .Rows.Item(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                .Rows.Item(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkRed
                .Rows.Item(e.RowIndex).DefaultCellStyle.Font = New Font("Verdana", 8, FontStyle.Strikeout Or FontStyle.Bold)
            End If
        End With
    End Sub
