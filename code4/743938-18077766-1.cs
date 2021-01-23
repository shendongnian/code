    Option Strict On
    Option Explicit On
    Option Infer Off
    Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim results As System.Collections.Generic.IEnumerable(Of Integer)
        results = Power(2, 8)
        Dim sb As New System.Text.StringBuilder
        For Each num As Integer In results
            sb.Append(num.ToString & " ")
        Next
        MessageBox.Show(sb.ToString)
    End Sub
    Public Function Power(ByVal number As Integer, ByVal exponent As Integer) As System.Collections.Generic.IEnumerable(Of Integer)
        Dim result As New List(Of Integer)
        For index As Integer = 1 To exponent
            result.Add(Convert.ToInt32(Math.Pow(number, index)))
        Next
        Return result.AsEnumerable
    End Function
    End Class
