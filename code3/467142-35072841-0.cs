    Enum Parameter
        TotalCost
        Required
    End Enum
    Enum Comparator
        Less
        More
        Equals
    End Enum
    Class Criterion
        Public ReadOnly Parameter As Parameter
        Public ReadOnly Comparator As Comparator
        Public ReadOnly Value As Double
        Public Sub New(Parameter As Parameter, Comparator As Comparator, Value As Double)
            Me.Parameter = Parameter
            Me.Comparator = Comparator
            Me.Value = Value
        End Sub
    End Class
