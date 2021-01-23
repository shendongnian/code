         Public Function StartTransaction() As Boolean
            Dim result As Boolean = False
            mTransactionConnection = New SqlConnection(_ConnectionString)
            mTransactionConnection.Open()
            mTransaction = mTransactionConnection.BeginTransaction()
            result = True
            
            Return result
        End Function
		
		Public Function RunSQL(ByVal strSQL As String) As Integer
            Dim intReturn As Integer = 0
            Dim objSQLConnection As SqlConnection
            Dim objSQLCommand As SqlCommand
            objSQLConnection = New SqlConnection(_ConnectionString)
            objSQLCommand = New SqlCommand(strSQL, objSQLConnection)
            objSQLCommand.CommandType = CommandType.Text
            objSQLCommand.CommandTimeout = intCommandTimeOut
            'set  params
            objSQLConnection.Open()
            'execute SQL
            intReturn = objSQLCommand.ExecuteNonQuery()
            objSQLCommand.Dispose()
            objSQLConnection.Close()
            return intReturn
			
        End Function
		
		Public Sub CommitTransaction()
            mTransaction.Commit()
           
        End Sub
        Public Sub RollbackTransaction()
            mTransaction.Rollback()
        End Sub
		
		Public Sub CloseTransaction()
            mTransaction.Dispose()
            mTransactionConnection.Close()
            
            mTransaction = Nothing
            mTransactionConnection = Nothing
        End Sub
