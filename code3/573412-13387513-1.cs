    Public Class EventData
    Public Property CompetitorName As String
    ' ... Other Info you've inputted
    Public Property EventName As String = ""
    Public Property Category As String = ""
    Public Property Score As Double = -1
    Public Property Time As Double = -1
    Public ReadOnly Property ComparisonVal As Double
        Get
            ' This could be either Score or Time
            ' Decide based upon which one <> -1 or something along those lines
        End Get
    End Property
    End Class
