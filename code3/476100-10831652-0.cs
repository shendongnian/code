             System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);
            _HttpWebRequest.AllowWriteStreamBuffering = true;
             
            // set timeout for 20 seconds (Optional)
            _HttpWebRequest.Timeout = 20000;
            // Request response:
            System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();
            // Open data stream:
            System.IO.Stream _WebStream = _WebResponse.GetResponseStream();
