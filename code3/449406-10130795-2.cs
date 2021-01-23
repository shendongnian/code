    Private Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        Select Case FormView1.CurrentMode
            Case FormViewMode.ReadOnly
                ' adjust the DataSource accordingly if its not a DataRow '
                Dim row = DirectCast(FormView1.DataItem, DataRow)
                Dim LblSex = DirectCast(FormView1.FindControl("LblSex"), Label)
                Dim sex As String = row.Field(Of String)("Sex")
                LblSex.Text = If(sex Is Nothing, "", sex)
            Case FormViewMode.Edit
                ' adjust the DataSource accordingly if its not a DataRow '
                Dim row As DataRow = DirectCast(FormView1.DataItem, DataRow)
                ' assuming your RadioButtonList is inside the EditItemTemplate '
                Dim RblSex = DirectCast(FormView1.FindControl("RblSex"), RadioButtonList)
                Dim sex As String = row.Field(Of String)("Sex")
                If Not sex Is Nothing Then RblSex.SelectedValue = sex
            Case FormViewMode.Insert
        End Select
    End Sub
