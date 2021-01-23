    Public Class FluidButton
     
        Public Property Content As String
        Public Property LeftPos As Double
        Public Property TopPos As Double
        Public Property ProductId As Double
     
        'Returns the Control Margin, using the Class Properties
        Public ReadOnly Property ControlMargin As Thickness
            Get
                Return New Thickness With {.Left = LeftPos, .Top = TopPos}
            End Get
        End Property
        
    End Class
