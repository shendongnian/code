    Public Sub MyGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(0).Text = "((value of row to hide))" Then
                e.Row.Visible = False
            Else
                e.Row.Visible = True
            End If
        End If
    End Sub
