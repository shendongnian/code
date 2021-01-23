    Private Sub ButtonAction_Click(sender As Object, e As System.EventArgs) Handles ButtonAction.Click
        Dim PasswordConnection = New PasswordAuthenticationMethod("test", "test")
        Dim KeyboardInteractive = New KeyboardInteractiveAuthenticationMethod("test")
        Dim ConnectionInfo = New ConnectionInfo("192.168.1.1", 22, "test", PasswordConnection, KeyboardInteractive)
        AddHandler KeyboardInteractive.AuthenticationPrompt, _
        Sub(_sender As Object, _e As Renci.SshNet.Common.AuthenticationPromptEventArgs)
            For Each prompt In _e.Prompts
                Debug.Print(prompt.Request)
                If Not prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) = -1 Then
                    prompt.Response = "test"
                End If
            Next
        End Sub
        sftp = New SftpClient(ConnectionInfo)
        sftp.Connect()
        sftp.disconnect()
    End Sub
