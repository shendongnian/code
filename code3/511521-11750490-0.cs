    Chilkat.SFtp sftp = new Chilkat.SFtp();
    
    //  Any string automatically begins a fully-functional 30-day trial.
    bool success;
    success = sftp.UnlockComponent("Anything for 30-day trial");
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  Set some timeouts, in milliseconds:
    sftp.ConnectTimeoutMs = 5000;
    sftp.IdleTimeoutMs = 10000;
    
    //  Connect to the SSH server.
    //  The standard SSH port = 22
    //  The hostname may be a hostname or IP address.
    int port;
    string hostname;
    hostname = "www.my-ssh-server.com";
    port = 22;
    success = sftp.Connect(hostname,port);
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  Authenticate with the SSH server.  Chilkat SFTP supports
    //  both password-based authenication as well as public-key
    //  authentication.  This example uses password authenication.
    success = sftp.AuthenticatePw("myLogin","myPassword");
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  After authenticating, the SFTP subsystem must be initialized:
    success = sftp.InitializeSftp();
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  Open a file on the server:
    string handle;
    handle = sftp.OpenFile("hamlet.xml","readOnly","openExisting");
    if (handle == null ) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  Download the file:
    success = sftp.DownloadFile(handle,"c:/temp/hamlet.xml");
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
    
    //  Close the file.
    success = sftp.CloseHandle(handle);
    if (success != true) {
        MessageBox.Show(sftp.LastErrorText);
        return;
    }
