    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not IsNothing(Session("myButtonWasClicked")) Then
                Dim content As String = "<p>This is an example of modal window.</p>" 'make sure to escape any characters that need escaping
                Dim sb As New StringBuilder
                sb.Append("<script type='text/javascript'>openModal('" + content + "');</script>")
                Dim page As Page = HttpContext.Current.CurrentHandler
                Dim cs As ClientScriptManager = page.ClientScript
                cs.RegisterClientScriptBlock(GetType(Reports), "modulFunction", sb.ToString, False)
                Session("myButtonWasClicked") = Nothing
            End If
        End If
    End Sub
    
    Protected Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
        Session("myButtonWasClicked") = 1
    End Sub
