    Private Sub InsertSQL(ByVal param1 As String, ByVal param2 As String, ByVal param3 As String)
        Using sqlConn As New SqlConnection("ConnectionStringHere")
            Using sqlComm As New SqlCommand()
                sqlComm.Connection = sqlConn
                sqlComm.CommandType = CommandType.Text
                sqlComm.CommandText = "INSERT INTO theTable VALUES (@Param1,@Param2,@Param3,@Param4,@Param5)"
                With sqlComm.Parameters
                    .AddWithValue("@Param1", param1)
                    .AddWithValue("@Param2", param2)
                    .AddWithValue("@Param3", param3)
                    .AddWithValue("@Param4", Now)
                    .AddWithValue("@Param5", Now)
                End With
                Try
                    sqlConn.Open()
                    sqlComm.ExecuteNonQuery()
                Catch ex As SqlException
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "Error No. " & ex.ErrorCode.ToString)
                Finally
                    sqlConn.Close()
                End Try
            End Using
        End Using
    End Sub
