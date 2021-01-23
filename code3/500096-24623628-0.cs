    public static StreamReader LoadWeb(string URL)
        {
            if (!URL.StartsWith("http"))
            {
                URL = "http://" + URL;
            }
            HttpWebResponse myResponse = null;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(new Uri(URL));
            
            System.IO.Stream myStream = null;
            StreamReader myStreamReader = null;
            myRequest.Method = "GET";
            myRequest.Proxy = null;
            myRequest.Timeout = 60000;
            myRequest.KeepAlive = false;
            try
            {
                myResponse = (HttpWebResponse)myRequest.GetResponse();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error : " + ex.Message);
                return null;
            }
            if (myResponse != null)
            {
                if (myResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    myStream = myResponse.GetResponseStream();
                    myStreamReader = new StreamReader(myStream);
                }
            }
            return myStreamReader;
        }
