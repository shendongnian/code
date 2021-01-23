    void HandleKeyEvent(Object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = password;
                }
            }
        }
    private bool connectToServer()
    {
        try
        {
            KeyboardInteractiveAuthenticationMethod kauth = new KeyboardInteractiveAuthenticationMethod(username);
            PasswordAuthenticationMethod pauth = new PasswordAuthenticationMethod(username, password);
            kauth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
            ConnectionInfo connectionInfo = new ConnectionInfo(serverName, port, username, pauth, kauth);
            sshClient = new SshClient(connectionInfo);
            sshClient.Connect();
            return true;
            }
        catch (Exception ex)
        {
            if (null != sshClient && sshClient.IsConnected)
            {
                sshClient.Disconnect();
            }
            throw ex;
        }
    }
 
