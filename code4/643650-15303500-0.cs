            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("user", "password");
            System.Net.CredentialCache cc = new System.Net.CredentialCache();
            cc.Add(new Uri("ftp://m3database"), "Basic", nc);
            System.Net.FtpWebRequest ftprequest = (System.Net.FtpWebRequest)System.Net.WebRequest.Create("ftp://m3database/recover/");
            ftprequest.Credentials = cc;
            ftprequest.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
             using (var resp = ftprequest.GetResponse())
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    MessageBox.Show(reader.ReadToEnd());
                }
            }
