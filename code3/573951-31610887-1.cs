                        string FtpAddress = "??.??.??.??";
                        string Port = "21";
                        string Username = "my-username";
                        string Password = "P455w0rd";
                        string FolderPath = "folder-name\\"; 
                        string Filename = "filename.foo";
                        string KeyFilename = "keyFilename.bar";
                        string KeyPassword= "K3yP455w0rd";
                        if (DataFeedInstance.MainContent.SftpCSVFile(FtpAddress, Username, Password, Port, FolderPath, Filename, ",", KeyFilename, KeyPassword))
                        {
                            /* Success */
                        }
                        else
                        {
                            /* Error */
                        }
