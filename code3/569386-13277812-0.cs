    Protected Sub myRepeater_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles myRepeater.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim uG As URLGroup = CType(e.Item.DataItem, URLGroup)
            '' you now have the group for that one item
            '' you should now be able to get additional information needed.
            '' you can also get the myLabel from this item 
            dim lbl as Label = CType(e.Item.FindControl("myLabel", Label)
            '' and set its text to whatever you need
            lbl.Text = MyCounter
        End If
    End Sub
