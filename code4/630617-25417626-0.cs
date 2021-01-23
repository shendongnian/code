    ' Usage Example:
    ' Dim ReadBytes As Byte() = ReadMemoryMappedFile(Name:="My MemoryMappedFile Name") ' Read the byte-sequence from memory.
    ' Dim Message As String = System.Text.Encoding.ASCII.GetString(ReadBytes.ToArray) ' Convert the bytes to String.
    ' Message = Message.Trim({ControlChars.NullChar}) ' Remove null chars (leading zero-bytes)
    ' MessageBox.Show(Message, "", MessageBoxButtons.OK) ' Show the message.    '
    '
    ''' <summary>
    ''' Reads a byte-sequence from a <see cref="IO.MemoryMappedFiles.MemoryMappedFile"/> without knowing the exact size.
    ''' Note that the returned byte-length is rounded up to 4kb, 
    ''' this means if the mapped memory-file was written with 1 byte-length, this method will return 4096 byte-length. 
    ''' </summary>
    ''' <param name="Name">Indicates an existing <see cref="IO.MemoryMappedFiles.MemoryMappedFile"/> assigned name.</param>
    ''' <returns>System.Byte().</returns>
    Private Function ReadMemoryMappedFile(ByVal Name As String) As Byte()
        Try
            Using MemoryFile As IO.MemoryMappedFiles.MemoryMappedFile =
                IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting(Name, IO.MemoryMappedFiles.MemoryMappedFileRights.ReadWrite)
                Using Stream = MemoryFile.CreateViewStream()
                    Using Reader As New BinaryReader(Stream)
                        Return Reader.ReadBytes(CInt(Stream.Length))
                    End Using ' Reader
                End Using ' Stream
            End Using ' MemoryFile
        Catch exNoFile As IO.FileNotFoundException
            Throw
            Return Nothing
        Catch ex As Exception
            Throw
        End Try
    End Function
