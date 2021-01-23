    Protected Sub gE_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gE.RowDataBound
        Dim lapt_Trig As New AsyncPostBackTrigger
        lapt_Trig.ControlID = e.Row.FindControl("MyButton").ID     
        up_UpdatePanel.Triggers.Add(lapt_Trig)    
    End Sub
