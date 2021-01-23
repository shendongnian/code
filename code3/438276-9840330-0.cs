    Module Module1
        Sub Main()
            Dim res = FuzzyDateTime.Parse("next 2 months")
        End Sub
    End Module
    Public Interface IDateTimePattern
        Function Parse(text As String) As DateTime
    End Interface
    Public Class FuzzyDateTime
        Shared dayList As List(Of String) = New List(Of String)() From {"sun", "mon", "tue", "wed", "thu", "fri", "sat"}
        Shared parsers As List(Of IDateTimePattern) = New List(Of IDateTimePattern)()
        Shared Sub New()
            parsers.Add(New RegexDateTimePattern("next +([2-9]\d*) +months", New Func(Of Match, DateTime)(Function(x As Match)
                                                                                                              Dim val = Integer.Parse(x.Groups(1).Value)
                                                                                                              Return DateTime.Now.AddMonths(val)
                                                                                                          End Function)))
        End Sub
        Public Shared Function Parse(ByVal text As String) As DateTime
            text = text.Trim().ToLower()
            Dim dt = DateTime.Now
            For Each parser In parsers
                dt = parser.Parse(text)
                If Not dt = DateTime.MinValue Then
                    Exit For
                End If
            Next
            Return dt
        End Function
    End Class
    Public Class RegexDateTimePattern : Implements IDateTimePattern
        Protected inter As Func(Of Match, DateTime)
        Protected regEx As Regex
        Public Function Parse(text As String) As Date Implements IDateTimePattern.Parse
            Dim m = regEx.Match(text)
            If m.Success Then Return inter(m)
            Return DateTime.MinValue
        End Function
        Public Sub New(ByVal re As String, ByVal inter As Func(Of Match, DateTime))
            Me.regEx = New Regex(re)
            Me.inter = inter
        End Sub
    End Class
