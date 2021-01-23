    Public Class User
        Public Property FirstName As String
        Public Property LastName As String
        Public ReadOnly Property FullName() As String
            Get
                If String.IsNullOrEmpty(FirstName) AndAlso String.IsNullOrEmpty(LastName) Then
                    Return "No Name"
                Else
                    Return FirstName & " " & LastName
                End If
            End Get
        End Property
    End Class
