    Try
        If _parameterNames IsNot Nothing Then
            For i = 0 To _parameterNames.Length - 1
                _command.Parameters.AddWithValue(_parameterNames(i), _parameterVals(i))
            Next
        End If
    
        _noOfRowsAffected = _command.ExecuteNonQuery()
    Catch ex As SqlException
        ' Do stuff - logging, checking the exception message etc...
        ' Rethrow exception if you want the exception to bubble up
    Catch ex As Exception
        'MsgBox(ex.Message)
        _noOfRowsAffected = -1
    Finally
        If _connection.State = ConnectionState.Open Then
            _connection.Close()
            _connection.Dispose()
            _command.Dispose()
        End If
    End Try
