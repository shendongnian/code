    private void button1_Click(object sender, EventArgs e)
    {
        if (fileReader == null) fileReader = new StreamReader("File");
        List<string> paramList=new List<string>();
        string thisLine;
        for (int i = 0; i < 50; i++)
        {
            thisLine = fileReader.ReadLine();
            if(thisLine=="")break;
            paramList.Add(fileReader.ReadLine());
        }
        foreach (string g in paramList)
        {
            dialogid++;
            netJob bwClass = new netJob(this.tbWebServiceURL.Text);
            bwClass.Fparameters.Add("number", g);
            bwClass.Fparameters.Add("dialogid", dialogid.ToString());
            backgroundWorker1.RunWorkerAsync(bwClass);
        }
    }
    class netJob
        {
            private string FURL;
            public Dictionary<string, string> Fparameters;
            public string errorMess;
            public string responseFromServer;
            public netJob(String URL)
            {
                FURL = URL;
                Fparameters=new Dictionary<string, string>();
                errorMess = "";
            }
            public void run()
            {
                InvokeService(FURL,Fparameters);
            }
    
            private bool InvokeService(string ServiceURL, Dictionary<string, string> parameters)
            {
                try
                {
                    string data = "";
                    byte[] dataStream = Encoding.UTF8.GetBytes(data);
                    WebRequest webRequest = WebRequest.Create("URL");
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.ContentLength = dataStream.Length;
    
                    foreach (KeyValuePair<string, string> kvk in parameters)
                    {
                        webRequest.Headers.Add(kvk.Key, kvk.Value);
                    }
    
                    WebResponse response = webRequest.GetResponse();
                    Stream dataStreamResponse = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStreamResponse);
                    responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    dataStreamResponse.Close();
                    response.Close();
                }
                catch (Exception e)
                {
                    errorMess = e.Message;
                }
            }
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            netJob thisJob = e.Argument as netJob;
            thisJob.run();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                netJob thisJob = e.Result as netJob;
                if (thisJob.errorMess == "") Console.WriteLine(thisJob.responseFromServer);
                else
                    MessageBox.Show("ERROR!", thisJob.errorMess);
        }
