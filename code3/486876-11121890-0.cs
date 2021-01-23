    Try
                Using sr As New StreamReader("TestFile.txt")
                    Dim line As String
                    Do
                        line = sr.ReadLine()
                        If Not (line Is Nothing) Then
                           Console.WriteLine(line)
                        End If
                    Loop Until line Is Nothing
                End Using
            Catch e As Exception
                Console.WriteLine("The file could not be read:")
                Console.WriteLine(e.Message)
            End Try
;)
