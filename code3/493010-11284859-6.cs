    Using connection As SqlConnection = Global.Connection.GetDbConnection()
        Using command As New SqlCommand(sql, connection)
            If parameterNames IsNot Nothing Then
                For i = 0 To parameterNames.Length - 1
                    command.Parameters.AddWithValue(parameterNames(i), parameterVals(i))
                Next
            End If
            noOfRowsAffected = _command.ExecuteNonQuery()
        End Using
    End Using
