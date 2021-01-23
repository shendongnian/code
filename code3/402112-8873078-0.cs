    Public Sub bk()
        Try
            ''# DB.Connection can be any valid SQLConnection which you might already be using in your application
            Using con As New SqlClient.SqlConnection(LIC.My.Settings.LICConnectionString)
                Dim srvCon As New ServerConnection(con)
                Dim srv As Server = New Server(srvCon)
    
                If srv.Databases.Contains(con.Database) Then
                    srv.KillAllProcesses(con.Database)
    
                    srv.DetachDatabase(con.Database, True)
    
                    System.IO.File.Copy(srv.MasterDBPath, "c:\backup\LIC.mdf", True)
                    System.IO.File.Copy(srv.MasterDBLogPath, "c:\backup\LIC_log.ldf", True)
    
                    MessageBox.Show("Backup taken successfully")
                End If
                srvCon.Disconnect()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error Occured : " & ex.Message)
        End Try
    End Sub
