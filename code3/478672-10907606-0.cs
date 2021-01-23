      Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim strInputFilename As String = "C:\Junk\Junk.pdf"
        Dim strOutputFilename As String = "C:\Junk\Junk2.pdf"
        Dim byt() As Byte
        Using ms As New MemoryStream
          '1. Load PDF into memory stream'
          Using bw As New BinaryWriter(ms)
            Using fsi As New FileStream(strInputFilename, FileMode.Open)
              Using br As New BinaryReader(fsi)
                Try
                  Do
                    bw.Write(br.ReadByte())
                  Loop
                Catch ex As EndOfStreamException
                End Try
              End Using
            End Using
          End Using
          byt = ms.ToArray()
        End Using
        '2. Write memory copy of PDF back to disk'
        My.Computer.FileSystem.WriteAllBytes(strOutputFilename, byt, False)
        Process.Start(strOutputFilename)
      End Sub
