        If rptSubCategorizedquestionList.Items IsNot Nothing AndAlso
            rptSubCategorizedquestionList.Items.Count > 0 Then
            For Each _item As RepeaterItem In rptSubCategorizedquestionList.Items
                If _item.ItemType = ListItemType.AlternatingItem OrElse
                         _item.ItemType = ListItemType.Item Then
                    Dim _hfCategoryID As HiddenField = _item.FindControl("hfCategoryID")
                    Dim _placeHolderSubCategoryQuestionItem As PlaceHolder = _item.FindControl("placeHolderSubCategoryQuestionItem")
                    Dim _nestedCategorizedListItemControlUserControlObject As UserControl =
                                                                    LoadControl("__categorizedQuestionListItem.ascx")
                    _nestedCategorizedListItemControlUserControlObject.ID =
                                          String.Format("ucCategorizedQuestionListItem", _hfCategoryID.Value)
                    _placeHolderSubCategoryQuestionItem.Controls.Add(_nestedCategorizedListItemControlUserControlObject)
                    Dim _nestedCategorizedListItem As Common_Questions__categorizedQuestionListItem =
                        DirectCast(_nestedCategorizedListItemControlUserControlObject, Common_Questions__categorizedQuestionListItem)
                End If
            Next
        End If
    End Sub
