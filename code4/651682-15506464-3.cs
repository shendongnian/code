    Public Class EntityTableRow
        Private ReadOnly _descritption As String
        Private ReadOnly _activity As String
        Private ReadOnly _monthCosts As IList(Of Decimal)
        Public Sub New( _
                ByVal description As String,
                ByVal activity As String, _
                ByVal monthCosts As IEnumerable(Of Decimal))
            Me._description = description
            Me._activity = activity
            Me._monthCosts = New List(Of Decimal)(monthCosts)
        End Sub
        Public ReadOnly Property Description() As String
            Get
                Return Me._description
            End Get
        End Property
        Public ReadOnly Property Activity() As String
            Get
                Return Me._activity
            End Get
        End Property
        Public ReadOnly Property MonthCosts() As IEnumerable(Of Decimal)
            Get
                Return Me._monthCosts
            End Get
        End Property
    End Class
