       Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
    
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
    
                Dim lds As LinqDataSource = CType(e.Item.FindControl("RadComboBox77"), LinqDataSource)
                CType(e.Item.FindControl("RadComboBox77"), RadComboBox).DataSourceID = lds.ID
    
            End If
    
    
        End Sub
