                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(sUri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(sFtpUserID, sFtpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
