    Public Class ReturnMessage(Of T)
        'indicates success or failure of the function
        Public Property IsSuccess As Boolean
        'messages(if any)
        Public Property Message As String
        'data (if any)
        Public Property Data As T
    End Class
