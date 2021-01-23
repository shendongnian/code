    Dim proc As System.Diagnostics.Process
            For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                If proc.MainWindowTitle.ToString = "" Then
                    proc.Kill()
                End If
            Next
