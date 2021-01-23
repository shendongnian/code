    public FTPClient(string userName, string password, string hostName, int port)
    {
        m_FtpInfo = new Ftp2();
        m_FtpInfo.Account = userName;
        m_FtpInfo.Hostname = hostName;
        m_FtpInfo.Password = password;
        //m_FtpInfo.Port = port;
    }
