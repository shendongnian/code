    Using cn As New SqlConnection(DataAccessResource.CONNECTIONSTRING)
        cn.Open()
        Using copy As New SqlBulkCopy(cn)
            copy.BulkCopyTimeout = 300
            copy.ColumnMappings.Add(0, 0)
            copy.ColumnMappings.Add(1, 1)
            copy.ColumnMappings.Add(2, 2)
            copy.ColumnMappings.Add(3, 3)
            copy.DestinationTableName = "Tablename"
            copy.WriteToServer(dataset.datatable)
        End Using
    End Using
