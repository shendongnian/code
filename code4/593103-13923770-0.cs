    private void ConnectBtn_Click(object sender, EventArgs e)
        {
            ListDirectory();
        }
        public string[] ListDirectory()
        {
            var list = listView1;
            var request = createRequest(TxtServer.Text, WebRequestMethods.Ftp.ListDirectory);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Items.Add(reader.ReadLine());
                        }
                    }
                }
            } List<string> l = new List<string>();
            return l.ToArray();
        }
        private FtpWebRequest createRequest(string uri, string method)
        {
            var r = (FtpWebRequest)WebRequest.Create(uri);
            r.Credentials = new NetworkCredential(TxtUsername.Text, TxtPassword.Text);
            r.Method = method;
            return r;
        }
