    Public Shared Function GetCorrectPropertyName(Of T) _
                 (ByVal expression As Expression(Of Func(Of T, Object))) As String
        If TypeOf expression.Body Is MemberExpression Then
            Return DirectCast(expression.Body, MemberExpression).Member.Name
        Else
            Dim op = (CType(expression.Body, UnaryExpression).Operand)
            Return DirectCast(op, MemberExpression).Member.Name
        End If
    End Function
