    for (int i = 0; i < phNos.Length; i++)
    {
        url = @"http://aaa.bbb.ccc.dd/HTTPMTAPI?User=abc&Password=pqr&FromAddr=xyzSMS&DestNo=" + phNos[i] + "&msg=" + message;
        Uri targetUri1 = new Uri(url);
        System.Net.HttpWebRequest hwb1;
        hwb1 = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(targetUri1);
        System.Net.HttpWebResponse response = hwb1.GetResponse();
        if (response != null)
            {
                int status = (int)response.StatusCode; // this changes the status 
                                                       // from text response to the
                                                       // number, like 404
                if (status == 404//or anything else you want to test//)
                   {
                        // put your retry logic here, make sure you add a way to break 
                        // so you dont infinitely loop if the service is down or something
                   }
        }
  }
