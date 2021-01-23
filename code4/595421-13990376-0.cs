    Dim ResponseStream As Stream = Response.GetResponseStream()
                Try
                    Dim reader As New StreamReader(Stream.Null)
                    Try
                        reader = New StreamReader(ResponseStream, System.Text.Encoding.GetEncoding(CharSet), True, 256)
                    Catch ex As Exception
                        
                        '
                        ' Redo the stream
                        '
                        If InStr(ex.Message, "not a supported encoding name.") > 0 Then
                            Try
                                reader = New StreamReader(ResponseStream, System.Text.Encoding.GetEncoding("utf-8"), True, 256)
                            Catch ex1 As Exception
                               
                            End Try
                        End If
                    End Try
                    '
                    'Dim string to build index.
                    '
                    Dim IndexBuildString As New StringBuilder()
                    Try
                        Dim read(256) As [Char]
                        '
                        ' Reads 256 characters at a time.    
                        '
                        Dim ByteCount As Integer = reader.Read(read, 0, 256)
                        '
                        ' Read in while, exit it if exceeds ~ 390 kb
                        '
                        While ByteCount > 0
                            '
                            'Check if limit of kilobytes are over the limit.
                            '
                            If System.Text.ASCIIEncoding.Unicode.GetByteCount(IndexBuildString.ToString()) > 153600 Then
                                Exit While
                            End If
                            '
                            'Dumps the 256 characters to a string and displays the string to the console.
                            '
                            Dim str As New [String](read, 0, ByteCount)
                            ByteCount = reader.Read(read, 0, 256)
                            '
                            'Append to the StringBuilder
                            '
                            IndexBuildString.Append(str)
                        End While
                        '
                        'Assign the Stringbuilder and then clear it
                        ' 
                        IndexString = CleanIndexString(IndexBuildString.ToString())
                    Catch ex As Exception
                        
                    Finally
                       
                        Try
                            IndexBuildString.Clear()
                            reader.Close()
                            reader.Dispose()
                        Catch ex As Exception
                            
                        End Try
                    End Try
                Catch ex As Exception
                    
                Finally
                    ResponseStream.Dispose()
                End Try
