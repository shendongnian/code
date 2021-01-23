    Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Assuming your ID column is in the first cell.
        If e.Row.RowType = DataControlRowType.DataRow AndAlso _
           (e.Row.Cells(0).Text = "21" OrElse e.Row.Cells(0).Text = "150") Then
            e.Row.BackColor = Drawing.Color.Blue
            'Assuming CheckBox is in the second cell with ID of "IdOfCheckBox"
            CType(e.Row.Cells(1).FindControl("IdOfCheckBox"), CheckBox).Checked = True
        End If
    End Sub
