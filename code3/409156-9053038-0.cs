    Private Sub myGrid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles myGrid.RowDataBound
    	If e.Row.RowType = DataControlRowType.DataRow Then
    		Dim picker As TimePicker = DirectCast(e.Row.FindControl("TimeSelector3"), TimePicker)
    	End If
    End Sub
