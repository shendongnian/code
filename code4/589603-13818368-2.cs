    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not IsNothing(Request.Form("hidValuesMessages")) Then
                Dim str As String = Request("hidValuesMessages")
            End If
            If Not IsNothing(Request.Form("hidValuesStatus")) Then
                Dim str2 As String = Request("hidValuesStatus")
            End If
        End If
    End Sub
