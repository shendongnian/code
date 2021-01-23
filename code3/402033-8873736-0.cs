    Private Sub Restore(ByVal ConnectionString As String, ByVal DatabaseFullPath As String, ByVal backUpPath As String)
        Using con As New SqlConnection(ConnectionString)
            con.Open()
            Dim sDatabaseName As String
            sDatabaseName = con.Database
            Dim UseMaster As String = "USE master"
            Dim UseMasterCommand As New SqlCommand(UseMaster, con)
            UseMasterCommand.ExecuteNonQuery()
            Dim Alter1 As String = "ALTER DATABASE [" & sDatabaseName & "] SET Single_User WITH Rollback Immediate"
            Dim Alter1Cmd As New SqlCommand(Alter1, con)
            Alter1Cmd.ExecuteNonQuery()
            Dim Restore As String = "RESTORE DATABASE [" & sDatabaseName & "] FROM DISK = N'" & backUpPath & "' WITH  FILE = 1,  NOUNLOAD,  STATS = 10"
            Dim RestoreCmd As New SqlCommand(Restore, con)
            RestoreCmd.ExecuteNonQuery()
            Dim Alter2 As String = "ALTER DATABASE [" & sDatabaseName & "] SET Multi_User"
            Dim Alter2Cmd As New SqlCommand(Alter2, con)
            Alter2Cmd.ExecuteNonQuery()
            MsgBox("Successful")
        End Using
    End Sub
