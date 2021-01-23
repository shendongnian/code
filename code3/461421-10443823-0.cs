    Partial Class TextControl
        Inherits System.Web.UI.UserControl
    
        Public Event ButtonClick(ByVal sender As Object, ByVal e As _
         System.EventArgs)
    
        Private Sub button1_onclick(ByVal sender As Object, ByVal e As _
         System.EventArgs) Handles button1.Click
    
            RaiseEvent ButtonClick(sender, e)
    
        End Sub
    
    End Class
