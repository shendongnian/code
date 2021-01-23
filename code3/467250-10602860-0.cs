    public class FTP
    {
        private String Username { get; set; }
        private String Password { get; set; }
        private String Host { get; set; }
        private Int32 Port { get; set; }
        public FTP(String username, String password, String host, Int32 port)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = port;
        }
        private Uri BuildServerUri(string Path)
        {
            return new Uri(String.Format("ftp://{0}:{1}/{2}", Host, Port, Path));
        }
        /// <summary>
        /// Upload a byte[] to the FTP server
        /// </summary>
        /// <param name="path">Path on the FTP server (upload/myfile.txt)</param>
        /// <param name="Data">A byte[] containing the data to upload</param>
        /// <returns>The server response in a byte[]</returns>
        private byte[] UploadData(string path, byte[] Data)
        {
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();
            try
            {
                // Logon to the server using username + password
                request.Credentials = new NetworkCredential(Username, Password);
                return request.UploadData(BuildServerUri(path), Data);
            }
            finally
            {
                if (request != null)
                    request.Dispose();
            }
        }
 
        /// <summary>
        /// Load a file from disk and upload it to the FTP server
        /// </summary>
        /// <param name="ftppath">Path on the FTP server (/upload/myfile.txt)</param>
        /// <param name="srcfile">File on the local harddisk to upload</param>
        /// <returns>The server response in a byte[]</returns>
        public byte[] UploadFile(string ftppath, string srcfile)
        {
            // Read the data from disk
            FileStream fs = new FileStream(srcfile, FileMode.Open);
            try
            {
                byte[] FileData = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fs.Read(FileData, numBytesRead, numBytesToRead);
                    // Break when the end of the file is reached.
                    if (n == 0) break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = FileData.Length;
                
                // Upload the data from the buffer
                return UploadData(ftppath, FileData);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (fs != null)
                    fs.Dispose();
            }
        }
    }
