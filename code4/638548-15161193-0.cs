    Protected Sub rptCol_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptCol.ItemDataBound
        If Not e.Item.ItemType = ListItemType.AlternatingItem AndAlso Not e.Item.ItemType = ListItemType.Item Then Exit Sub
        If e.Item.ItemIndex > 3 Then
            Exit Sub
        End If
     .....
    End Sub
