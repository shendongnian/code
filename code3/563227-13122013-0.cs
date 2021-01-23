    class Program
        {
            static void Main(string[] args)
            {
                using (var connection = new FTPConnection
                {
                    ServerAddress = "127.0.0.1",
                    UserName = "Admin",
                    Password = "1",
                })
                {
    
    
                    connection.Connect();
                    connection.ServerDirectory = "/recursive_folder";
                    var resultRecursive =
                        connection.GetFileInfosRecursive().Where(f => !(f.Name.EndsWith(".old"))).ToList();
                    var resultDefault = connection.GetFileInfos().Where(f => !(f.Name.EndsWith(".old"))).ToList();
    
    
                }
                
            }
        }
    
        public static class FtpClientExtensions
        {
            public static FTPFile[] GetFileInfosRecursive(this FTPConnection connection)
            {
                var resultList = new List<FTPFile>();
                var fileInfos = connection.GetFileInfos();
                resultList.AddRange(fileInfos);
                foreach (var fileInfo in fileInfos)
                {
                    if (fileInfo.Dir)
                    {
                        connection.ServerDirectory = fileInfo.Path;
                        resultList.AddRange(connection.GetFileInfosRecursive());
                    }
                }
                return resultList.ToArray();
            }
        }
