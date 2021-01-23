     Protected Sub ddl_Srv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Bind_List()
            If Session("ddl1_selection") IsNot Nothing Then
                dropdownlist1.SelectedValue = Session("ddl1_selection")
            End If
        End If
    End Sub
