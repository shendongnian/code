    Private Sub DownloadFile(relativeUrl As String, destinationPath As String, name As String)
        Try
            destinationPath = Replace(destinationPath + "\" + name, "\\", "\")
            Dim fi As FileInformation = Microsoft.SharePoint.Client.File.OpenBinaryDirect(Me.context, relativeUrl)
            Dim down As Stream = System.IO.File.Create(destinationPath)
            Dim a As Integer = fi.Stream.ReadByte()
            While a <> -1
                down.WriteByte(CType(a, Byte))
                a = fi.Stream.ReadByte()
            End While
        Catch ex As Exception
            ToLog(Type.ERROR, ex.Message)
        End Try
    End Sub
