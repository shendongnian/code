    Private Sub MesgBox(ByVal sMessage As String)
      Dim serializer as New System.Web.Script.Serialization.JavaScriptSerializer()
      Dim msgedtble As String = serializer.Serialize(sMessage)
      Page.ClientScript.RegisterStartupScript(Me.GetType, "myScripts",
        "<script type='text/javascript'>alert(" & msgedtble & ");</script>")
    End Sub
