    ' Part 2: Create one Table using OLEDB Provider 
        Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & databaseName)
        con.Open()
        'Get database schema
        Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, tableName, "TABLE"})
      con.Close()
 
        ' If the table exists, the count = 1
        If dbSchema.Rows.Count > 0 Then
            ' do whatever you want to do if the table exists
        Else
            'do whatever you want to do if the table does not exist
            ' e.g. create a table
            Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" + tableName + "] ([Field1] TEXT(10), [Field2] TEXT(10))", con)
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Table Created Successfully")
            con.Close()
        End If
