    Sftp sftp = new Sftp(sftpHost, sftpUser);
    Console.WriteLine("success");
    // assuming public/private key authentication here...
    sftp.AddIdentityFile(privateKeyFileName, privateKeyFilePassPhrase);
    sftp.Connect(sftpPort);
    ArrayList files = sftp.GetFileList(".");                
    foreach (string file in files)
    {
    Console.WriteLine("\t{0}", file);
    }
    sftp.Close();
