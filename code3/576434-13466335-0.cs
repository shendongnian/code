    Public MustInherit Class BaseUC
    Inherits System.Web.UI.UserControl
    ' Define all page controls here
    Public MustOverride Property lblPageTitle As Label
    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Check if control has been initialized by inheriting class
        If lblPageTitle IsNot Nothing Then
            lblPageTitle.Text = "Hooray"
        End If
    End Sub
    End Class
