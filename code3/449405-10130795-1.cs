    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sex = getSexFromStoredProcedure()
            If Not sex Is Nothing Then rd.SelectedValue = sex
        End If
    End Sub
