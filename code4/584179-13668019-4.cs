    Public Class A
        Public Shared X As Integer
        Friend Shared Y As Integer
        Private Shared Z As Integer
    End Class
    Friend Class B
        Public Shared X As Integer
        Friend Shared Y As Integer
        Private Shared Z As Integer
        Public Class C
            Public Shared X As Integer
            Friend Shared Y As Integer
            Private Shared Z As Integer
        End Class
        Private Class D
            Public Shared X As Integer
            Friend Shared Y As Integer
            Private Shared Z As Integer
        End Class
    End Class
