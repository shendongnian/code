    static ManualResetEvent m_reset = new ManualResetEvent(false);
    void Main()
    {
        m_reset.Reset();
        using (FtpClient ftp = new FtpClient())
        {
            ftp.Host = "yourFTPHost.com";
            ftp.Credentials = new NetworkCredential("yourUserName", "yourPassword");
            ftp.SetWorkingDirectory("/rootForTest");
            if(ftp.DirectoryExists("test"))
                ftp.DeleteDirectory("test", true);
            ftp.BeginCreateDirectory("test/path/that/should/be/created", true,
                        new AsyncCallback(CreateDirectoryCallback), ftp);
            m_reset.WaitOne();
            ftp.Disconnect();
        }
    }
    static void CreateDirectoryCallback(IAsyncResult ar) 
    {
        FtpClient ftp = ar.AsyncState as FtpClient;
        try 
        {
            if (ftp == null)
                 throw new InvalidOperationException("The FtpControlConnection object is null!");
            ftp.EndCreateDirectory(ar);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString());
        }
        finally 
        {
            m_reset.Set();
        }
    }
