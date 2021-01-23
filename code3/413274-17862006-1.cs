    Protected Sub yourDataGrid_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles yourDataGrid.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Me.Page.ClientScript.GetPostBackEventReference(Me.yourDataGrid, "Select$" & e.Row.RowIndex)
        End If
    End Sub
