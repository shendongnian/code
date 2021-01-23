    Public Class CustomFormatter
        Implements IFormatProvider
        Implements ICustomFormatter
        Public Function Format(format__1 As String, arg As Object, formatProvider As IFormatProvider) As String Implements ICustomFormatter.Format
            ' format doubles to 3 decimal places
            If IsNumber(arg) Then
                Dim number As Double = Convert.ToDouble(arg)
                If number < 1 Then
                    Return String.Format("{0:0.000}", arg)
                ElseIf number < 10 Then
                    Return String.Format("{0:0.00}", arg)
                End If
                Return String.Format("{0:0}", arg)
            Else
                Return String.Format(format__1, arg)
            End If
        End Function
    
        Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
            Return If((formatType = GetType(ICustomFormatter)), Me, Nothing)
        End Function
    
        Public Shared Function IsNumber(value As Object) As Boolean
            Return TypeOf value Is SByte OrElse TypeOf value Is Byte OrElse TypeOf value Is Short OrElse TypeOf value Is UShort OrElse TypeOf value Is Integer OrElse TypeOf value Is UInteger OrElse TypeOf value Is Long OrElse TypeOf value Is ULong OrElse TypeOf value Is Single OrElse TypeOf value Is Double OrElse TypeOf value Is Decimal
        End Function
    End Class
    
    Private Sub Main()
        For Each val As Object In (New Object() {0, 0.05, 1, 1.0, 1.5, 9.9, _
            10, 10D, &Hff})
            Console.WriteLine(Convert.ToString(val) & " : " & String.Format(New CustomFormatter(), "{0}", val))
        Next
    End Sub
