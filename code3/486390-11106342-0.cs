    Private Function getRegistryString(ByVal sVal As String, Optional ByVal sKey As String = "") As String
        Dim s As String
        Try
            s = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey).GetValue(sVal)
        Catch ex As Exception
            l.EventLog(ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
        Return s
    End Function
