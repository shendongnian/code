    Public Function GetMailFolderByName(ByVal folderName As String) As Folder Implements IMailboxExchange.GetMailFolderByName
        Me.ThrowIfNoConnection()
        Dim folderView As FolderView = New FolderView(1)
        folderView.PropertySet = New PropertySet(BasePropertySet.IdOnly)
        folderView.PropertySet.Add(FolderSchema.DisplayName)
        folderView.Traversal = FolderTraversal.Deep
        Dim searchFilterByFolderName As SearchFilter = New SearchFilter.ContainsSubstring(FolderSchema.DisplayName, folderName)
        Dim results As FindFoldersResults = Me._exchangeService.FindFolders(WellKnownFolderName.Root, searchFilterByFolderName, folderView)
        If results Is Nothing OrElse results.Folders Is Nothing OrElse results.Folders.Count = 0 Then
            Return Nothing
        End If
        Return results.Folders(0)
    End Function
