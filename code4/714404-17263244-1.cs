    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security;
    using System.Windows.Forms;
    
    namespace ConsoleApplication5
    {
        public class FtpTest
        {
            string server = "servier/";
            string user = "user";
            SecureString passw = new SecureString();
    
            public List<string> GetFilesOnServer()
            {
                return GetFilesOnServer(server);
            }
    
            public List<string> GetFilesOnServer(string dir)
            {
                var root = GetDirectoryContents(dir);
                var files = new List<string>();
    
                foreach (string name in root)
                {
                    var path = GetFullPath(dir, name);
                    if (IsDirectory(name))
                    {
                        var subFiles = GetFilesOnServer(path);
                        files.AddRange(subFiles);
                    }
                    else
                    {
                        files.Add(path);
                    }
                }
    
                return files;
            }
    
            public List<string> GetDirectoryContents(string dir)
            {
                var files = new List<string>();
    
                try
                {
                    var ftpwrq = (FtpWebRequest)WebRequest.Create(dir);
                    ftpwrq.Credentials = new NetworkCredential(user, passw);
                    ftpwrq.Method = WebRequestMethods.Ftp.ListDirectory;
                    ftpwrq.KeepAlive = false;
                    var fresponse = (FtpWebResponse)ftpwrq.GetResponse();
                    var sr = new StreamReader(fresponse.GetResponseStream());
                    string fileName = "";
                    while ((fileName = sr.ReadLine()) != null)
                    {
                        files.Add(fileName);
                    }
                    sr.Close();
                    fresponse.Close();
                    return files;
                }
                catch (ArgumentException)
                {
    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
    
                return files;
            }
    
            public static string GetFullPath(string dir, string file)
            {
                string path = dir;
                if (!path.EndsWith("/"))
                    path += "/";
                path += file;
                return path;
            }
    
            public static bool IsDirectory(string name)
            {
                return name.IndexOf(".") > 0;
            }
        }
    }
