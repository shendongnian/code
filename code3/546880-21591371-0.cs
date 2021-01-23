    Private Function DecodeToken(encodedToken As String, key As String) As String
        Dim scrambled = Convert.FromBase64String(encodedToken)
        Dim buffer As Byte()
        Dim index As Integer
        If Not Scramble(scrambled, key, buffer) Then
            Return Nothing
        End If
        Dim descrambled = System.Text.Encoding.Unicode.GetString(buffer, 0, buffer.Length);
        Return descrambled
    End Function
