    Imports System.Reflection
    Public Class Test
      Public Shared x As String = "100"
      Public Shared y As String = "text"
      Public Shared z As String = "something"
      Function giveVar(ByVal varName As String) As String
        Dim pi As FieldInfo = Me.GetType().GetField(varName)
        Return (pi.GetValue(Me)).ToString()
      End Function
    End Class
