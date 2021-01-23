      string result; 
      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
           using (StreamReader reader = new StreamReader(response.GetResponseStream()))
           {
                result = reader.ReadToEnd();
           }
      }
