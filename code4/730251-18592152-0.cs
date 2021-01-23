            Try
                'Job implementation goes here
                Dim jobConnection As System.Data.SqlClient.SqlConnection
                Dim jobCommand As SqlCommand
                Dim jobParameter As SqlParameter
                Dim jobReturnValue As SqlParameter
                Dim jobResult As Integer
    
                
                jobConnection = New System.Data.SqlClient.SqlConnection(SSISConnectionString)
                jobCommand = New SqlCommand("msdb.dbo.sp_start_job", jobConnection)
                jobCommand.CommandType = CommandType.StoredProcedure
    
                jobReturnValue = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                jobReturnValue.Direction = ParameterDirection.ReturnValue
                jobCommand.Parameters.Add(jobReturnValue)
    
    
                jobParameter = New SqlParameter("@job_name", SqlDbType.VarChar)
                jobParameter.Direction = ParameterDirection.Input
                jobCommand.Parameters.Add(jobParameter)
                jobParameter.Value = packageName
    
                jobConnection.Open()
                jobCommand.ExecuteNonQuery()
                jobResult = DirectCast(jobCommand.Parameters("@RETURN_VALUE").Value, Integer)
    
                jobConnection.Close()
    
    
                Select Case jobResult
                    Case 0
                        'Successful run
                    Case Else
                        Throw New Exception("SQLAgent Job failed to start!")
                End Select
    
    
            Catch ex As Exception
                Return ex
            End Try
