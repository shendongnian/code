    public void GetListing() 
    {
        using (FtpClient conn = new FtpClient()) 
        {
            conn.Host = "your_ftp_site_url";
            conn.Credentials = new NetworkCredential("your_user_account", "your_user_password");
            foreach (FtpListItem item in conn.GetListing(conn.GetWorkingDirectory(),  FtpListOption.Modify | FtpListOption.Size)) 
            {
                  switch (item.Type) 
                  {
                        case FtpFileSystemObjectType.Directory:
                            Console.WriteLine("Folder:" + item.Name);
                            break;
                        case FtpFileSystemObjectType.File:
                            Console.WriteLine("File:" + item.Name);
                            break;
                }
            }
        }
    }
