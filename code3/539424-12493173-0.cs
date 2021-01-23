    Imports System.IO
    Imports System.Text
    
    Module Conversions
        Public Sub ConvertAsciiToEbcdic(ByVal inpath As String, ByVal outpath As String)
            Using sr As New StreamReader(inpath, Encoding.ASCII)
                Using sw As New StreamWriter(outpath, False, Encoding.GetEncoding(37))
                    Do
                        Dim line = sr.ReadLine()
                        If line Is Nothing Then Exit Do
                        sw.WriteLine(line)
                    Loop
                End Using
            End Using
        End Sub
    End Module
