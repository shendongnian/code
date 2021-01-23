    ManualResetEvent done = new ManualResetEvent(false);
    
    void Main()
    {        
        // set physical address of network adapter to monitor operational status
        string physicalAddress = "00215A6B4D0F";
        
        // create web request
        var request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://stackoverflow.com"));
        
        // create timer to cancel operation on loss of network
        var timer = new System.Threading.Timer((s) => 
        {
            NetworkInterface networkInterface = 
                NetworkInterface.GetAllNetworkInterfaces()
                    .FirstOrDefault(nic => nic.GetPhysicalAddress().ToString() == physicalAddress);
                    
            if(networkInterface == null)
            {
                throw new Exception("Could not find network interface with phisical address " + physicalAddress + ".");
            }
            else if(networkInterface.OperationalStatus != OperationalStatus.Up)
            {
                Console.WriteLine ("Network is down, aborting.");
                request.Abort();
                done.Set();
            }
            else
            {
                Console.WriteLine ("Network is still up.");
            }
        }, null, 100, 100);
        
        // start asynchronous request
        IAsyncResult asynchResult = request.BeginGetResponse(new AsyncCallback((o) =>
        {
            try
            {	        
                var response = (HttpWebResponse)request.EndGetResponse((IAsyncResult)o); 
                var reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                var writer = new StringWriter();
                writer.Write(reader.ReadToEnd());
                Console.Write(writer.ToString());
            }
            finally
            {
                done.Set();
            }
        }), null);
    
        // wait for the end
        done.WaitOne();
    }
