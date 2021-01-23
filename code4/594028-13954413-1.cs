    Public Class Person
        Property NickName As String
        Property Name As String
    End Class
    Sub Main()
        Dim p1 As New List(Of Person)
        '*** Fill the list here ***
        Dim q = (From p In p1
                 Where p.Name.First = "A"
                 Select p.NickName, p.Name).ToDictionary(
                                               Function(k) k.NickName, 
                                               Function(v) v.Name)
    End Sub
