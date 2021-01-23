    public string DLWindowUser(string caption, string caption2, string remote, string local, string user, string password)
            {
                FStatus = new SZOKZZ.FrmStatus();
                FStatus.InitProc(100);
                FStatus.SetCaption(caption, caption2);
                _DlError = null;
                string ret = "";
                using (WebClient webClient = new WebClient())
                {
                    NetworkCredential c = new NetworkCredential();
                    c.UserName = user;
                    c.Password = password;
                    webClient.Credentials = c;
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DLDone);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DLSetProc);
                    webClient.DownloadFileAsync(new Uri(remote), local);
                    FStatus.ShowDialog();
                    if (_DlError != null)
                        ret = _DlError.Message;
                }
                return ret;
            }
