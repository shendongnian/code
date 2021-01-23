                Dim cmd As SqlCommand = New SqlCommand(SProcedure, cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddRange(parameters)
                If cnn.State = ConnectionState.Closed Then
                    cnn.Open()
                End If
                Dim Ls As Integer
                Ls= cmd.ExecuteNonQuery()
                If Ls = -1 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return False
            Finally
                cnn.Close()
            End Try
        End Using
    End Function
