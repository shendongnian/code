    Protected Sub btnCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheck.Click
        For Each listItem As ListItem In sect.Items
            listItem.Selected = True
        Next
    End Sub
    Protected Sub btnUncheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUncheck.Click
        For Each listItem As ListItem In sect.Items
            listItem.Selected = False
        Next
    End Sub
