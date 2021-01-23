            private void button1_Click(object sender, EventArgs e)
            {
                if (fileReader == null) fileReader = new StreamReader("File");
                string thisLine;
                netJob bwClass = new netJob(this.tbWebServiceURL.Text);
                for (int i = 0; i < 50; i++)
                {
                    thisLine = fileReader.ReadLine();
                    if(thisLine=="")break;
                    dialogid++;
                    Dictionary<string, string> newDict = new Dictionary<string, string>();
                    newDict.Add("number", thisLine);
                    newDict.Add("dialogid", dialogid.ToString());
                    bwClass.Fparams.Add(newDict);
                }
                backgroundWorker1.RunWorkerAsync(bwClass);
            }
    
    
    
        class netJob
        {
            private string FURL;
            public List< Dictionary<string, string> > Fparams;
            private Dictionary<string, string> FthisParam;
            public string errorMess;
            public string responseFromServer;
            public List<string> responsesFromServer;
            public netJob(String URL)
            {
                FURL = URL;
                Fparams= new List< Dictionary<string, string> >();
                responsesFromServer=new List<string>();
                errorMess = "";
            }
            public void run()
            {
                foreach (Dictionary<string, string> thisDict in Fparams)
                {
                    InvokeService(FURL, thisDict);
                    if (errorMess == "") responsesFromServer.Add(responseFromServer);
                    else
                    {
                        responsesFromServer.Add(errorMess);
                    }
    
                }
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
                    foreach (string thisResponse in thisJob.responsesFromServer)
                    {
                        Console.WriteLine(thisResponse);
                    }
            }
