    ''' <summary>Converts a byte array to a hexadecimal string.</summary>
    ''' <param name="Item">Required. The array of byte to convert.</param>
    ''' <returns>An hexadecimal string if converted successfully, error otherwise.</returns>
    <Extension()>
    Public Function [ToHexString](
        ByVal Item() As Byte) As String
        Dim Result As String = ""
        For Each b As Byte In Item
            Result += b.ToString("X2")
        Next b
        Return Result
    End Function
