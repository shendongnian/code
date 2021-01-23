    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(0).Text = "User <a href=""/profile.aspx?userid=12323"">" + DataBinder.Eval(e.Row.DataItem, "UserID") + "</a>"
            End If
    
    End Sub
