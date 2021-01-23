    private void DoWork(object o, DoWorkEventArgs e)
    {
        string Url = (string) e.Argument;
        List<of string> tmpList = new List<of string>;
    
        var request = createRequest(url, WebRequestMethods.Ftp.ListDirectory);
    
        using (var response = (FtpWebResponse)request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream, true))
                {
                    while (!reader.EndOfStream)
                    {
                        list.Add(reader.ReadLine());
                        //ResultLabel.Text = "Connected";
                        //use reportprogress() instead
                    }
                }
            }
        }
        e.result = tmpList;
    }
