    dim metabasePath as String = "IIS://localhost/W3svc/1"
    Private Sub SetProperty(ByVal metabasePath As String, ByVal propertyName As String, ByVal newValue As Object, clearCurrentValue As Boolean)
			Dim path As DirectoryEntry
			path = New DirectoryEntry(metabasePath)
			If clearCurrentValue Then path.Properties(propertyName).Clear()
			path.Properties(propertyName).Add(newValue)
			path.CommitChanges()
	End Sub
