    Private Function LoadFont(ByVal fontName As String, ByVal size As Integer, ByVal style As FontStyle) As Font
        Dim executingAssembly As System.Reflection.Assembly = Reflection.Assembly.GetCallingAssembly()
        Dim myNamespace As String = executingAssembly.GetName().Name.ToString()
        Try
            Using fontstream = executingAssembly.GetManifestResourceStream(myNamespace + "." + fontName)
                Dim fontBytes(CInt(fontstream.Length)) As Byte
                fontstream.Read(fontBytes, 0, CInt(fontstream.Length))
                Dim fontData As System.IntPtr = Marshal.AllocCoTaskMem(fontBytes.Length)
                Marshal.Copy(fontBytes, 0, fontData, fontBytes.Length)
                _sharedFontCollection.AddMemoryFont(fontData, fontBytes.Length)
                Marshal.FreeCoTaskMem(fontData)
            End Using
            Return New Font(_sharedFontCollection.Families(0), size, style)
        Catch ex As Exception
            'An unexpected error has occurred so return a default Font just in case.
            Return New Drawing.Font("Arial", size, FontStyle.Regular)
        End Try
    End Function
