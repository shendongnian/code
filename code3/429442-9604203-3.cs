    Public Function GetUsersByGroup(de As DirectoryEntry, groupName As String) As IEnumerable(Of DirectoryEntry)
        Dim userList As New List(Of DirectoryEntry)
        Dim group As DirectoryEntry = GetGroup(de, groupName)
        If group Is Nothing Then Return Nothing
        For Each user In GetUsers(de)
            If IsUserInGroup(user, group) Then
                userList.Add(user)
            End If
        Next
        Return userList
    End Function
    Public Function GetGroup(de As DirectoryEntry, groupName As String) As DirectoryEntry
        Dim deSearch As New DirectorySearcher(de)
        deSearch.Filter = "(&(objectClass=group)(SAMAccountName=" & groupName & "))"
        Dim result As SearchResult = deSearch.FindOne()
        If result Is Nothing Then
            Return Nothing
        End If
        Return result.GetDirectoryEntry()
    End Function
    Public Function GetUsers(de As DirectoryEntry) As IEnumerable(Of DirectoryEntry)
        Dim deSearch As New DirectorySearcher(de)
        Dim userList As New List(Of DirectoryEntry)
        deSearch.Filter = "(&(objectClass=person))"
        For Each user In deSearch.FindAll()
            userList.Add(user.GetDirectoryEntry())
        Next
        Return userList
    End Function
    Public Function IsUserInGroup(user As DirectoryEntry, group As DirectoryEntry) As Boolean
        Dim memberValues = user.Properties("memberOf")
        If memberValues Is Nothing OrElse memberValues.Count = 0 Then Return False
        For Each g In user.Properties("memberOf").Value
            If g = group.Properties("distinguishedName").Value.ToString() Then
                Return True
            End If
        Next
        Return False
    End Function
