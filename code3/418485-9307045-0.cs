    Public Sub InsertRow(ByVal param1 As String, ByVal param2 As String, ByVal param3 As String)
    
        Dim strConn As String = (the connection string)
        Dim sqlConn As New SqlConnection(strConn)
    
        Dim insertSQL As String = "INSERT INTO theTable VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + DateTime.Now + "', '" + DateTime.Now + "')"
        Dim comm As New SqlCommand(insertSQL, sqlConn)
        sqlConn.Open()
        comm.ExecuteNonQuery()
        sqlConn.Close()
        ReLoadData(grid)
    End Sub
    
    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
    
        InsertRow("a","b","c")
    
    End Sub
    Private Sub ReloadData(ByVAl sender as DataGridView)
     ' Implement your data load function
     ' I use for example
      sender.datasource = GetTable() 'GetTable is a function that return a DataTable Object With my data 
      sender.DataSource = Nothing    'Free the DataGridView DataSource property for enable row edition.
    
    End Sub
