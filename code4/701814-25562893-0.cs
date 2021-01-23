    Dim con As System.Data.IDbConnection
    Dim cmd As System.Data.IDbCommand                        
                           Select Case ConDBType
                                Case TypeDatabase.SqlServer
                                    con = New OleDbConnection(CN.ConnectionString)
                                    cmd = New OleDbCommand
                                Case TypeDatabase.MySql
                                    con = New MySqlConnection(CNMySql.ConnectionString)
                                    cmd = New MySqlCommand
                                Case TypeDatabase.Access
                                    Call InitNameing()
                                    ConDBAccess.DataSource = PreparToRootNameing() & "\T" & NAME_SYSTEMDB
                                    con = New OleDbConnection(CN.ConnectionString)
                                    cmd = New OleDbCommand
                           End Select
                           cmd.Connection = con
                           con.Open()
                           cmd.CommandText = SQLUpdate
                           cmd.ExecuteNonQuery()
