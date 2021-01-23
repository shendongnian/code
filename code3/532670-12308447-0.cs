    Sub GridView_RowDataBound(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    
        If e.Row.RowType = DataControlRowType.DataRow Then
                    If (Check your condition ) Then
                    e.Row.BackColor = Drawing.Color.Blue
                    'Then find your checkbox control from row and set it's value to Checked...
    
       ELSE
         e.Row.BackColor = Drawing.Color.yellow
      
     End If
        End If
    End Sub
