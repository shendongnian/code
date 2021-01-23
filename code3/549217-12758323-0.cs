    for(int i=0;i<phNos.Length;i++)
    {
      try
      {
        url = "baseurl/PushURL.fcgi?0&mobileno=" + phNos[i] + "&message="+ masg;
        
        Uri targetUri = new Uri(url);
        System.Net.HttpWebRequest hwb;
        hwb = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(targetUri);
        hwb.GetResponse();
      }
      catch (...)
      { // error handling
      }
    }
