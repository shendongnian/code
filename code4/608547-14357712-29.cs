    Private Function EqualOrBothNull(ByVal int1 As Int32?, ByVal int2 As Int32?) As Boolean
        Select Case True
            Case (int1 Is Nothing AndAlso int2 Is Nothing)
                Return True
            Case (int1 Is Nothing AndAlso int2 IsNot Nothing) OrElse (int1 IsNot Nothing AndAlso int2 Is Nothing)
                Return False
            Case (int1 IsNot Nothing AndAlso int2 IsNot Nothing)
                Return int1 = int2
        End Select
    End Function
