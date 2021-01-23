    Public Function sqLiteGetDataTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Using cnn = New SQLiteConnection(dbConnection)
            cnn.Open()
            Using cmd As SQLiteCommand = cnn.CreateCommand()
                cmd.CommandText = sql
                Using reader As System.Data.SQLite.SQLiteDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                    reader.Dispose()
                End Using
                cmd.Dispose()
            End Using
            If cnn.State <> System.Data.ConnectionState.Closed Then
                cnn.Close()
            End If
            cnn.Dispose()
        End Using
        Return dt
    End Function
