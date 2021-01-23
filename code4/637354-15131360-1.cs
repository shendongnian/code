      Public Shared Function BulkSave(ByVal dt As DataTable) As Boolean
        Dim mydb As New CSdatabase
        Try
        Dim connectionString = "Connection String"
        '' so there is no need to map columns. 
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(connectionString)
                bulkCopy.BatchSize = 25000
                bulkCopy.BulkCopyTimeout = 300
                bulkCopy.ColumnMappings.Add("EmailID", "EmailID")
                bulkCopy.ColumnMappings.Add("Name", "Name")
                bulkCopy.ColumnMappings.Add("FileName", "FileName")
                bulkCopy.ColumnMappings.Add("IsDownloaded", "IsDownloaded")
                bulkCopy.DestinationTableName = "dbo.CandidateApplication"
                bulkCopy.WriteToServer(dt)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            'mydb.closeConnection() ' Close your conneciton here
        End Try
        Return True
    End Function
