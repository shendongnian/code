    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
       Handles Me.LoadComplete
        Dim Myname As String = "myName"
        Dim cstype As Type = Me.GetType()
        Page.ClientScript.RegisterStartupScript(cstype, "MyKey", "hello('"&Myname&"');",
      True)
    
    End Sub 
