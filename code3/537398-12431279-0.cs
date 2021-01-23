    Private Sub GenerateContactGridColumns()
        Dim clmName As New BoundField()
        clmName.DataField = "FriendName"
        clmName.HeaderText = "Name"
        Dim clmCity As New BoundField()
        clmCity.DataField = "City"
        clmCity.HeaderText = "City"
        Dim clmEdit As New CommandField()
        clmEdit.ButtonType = ButtonType.Image
        clmEdit.EditImageUrl = Me.ThemeImagesPath & "/edit.gif"
        clmEdit.DeleteImageUrl = Me.ThemeImagesPath & "/delete.gif"
        clmEdit.ShowEditButton = True
        clmEdit.ShowDeleteButton = True
        gvContacts.Columns.Clear()
        gvContacts.Columns.Add(clmName)
        gvContacts.Columns.Add(clmCity)
        gvContacts.Columns.Add(clmEdit)
    End Sub
