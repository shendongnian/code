    ''' <summary>Converts a byte array to a hexadecimal string.</summary>
    ''' <param name="Item">Required. The array of byte to convert.</param>
    ''' <returns>A hexadecimal string if converted successfully, error otherwise.</returns>
    <Extension()>
    Public Function [ToHexString](
        ByVal Item As Byte()) As String
        Dim Result As String = ""
        If Item IsNot Nothing Then
            For Each b As Byte In Item
                Result += b.ToString("X2")
            Next b
        End If
        Return Result
    End Function
