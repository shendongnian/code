        public void gethtml()
        {
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create("http://msnbc.com/");
            WebRequestObject.Timeout = (System.Int32)TimeSpan.FromSeconds(2).TotalMilliseconds;
            try
            {
                WebResponse Response = WebRequestObject.GetResponse();
                Stream WebStream = Response.GetResponseStream();
                StreamReader Reader = new StreamReader(WebStream);
                string webcontent = Reader.ReadToEnd();
                MessageBox.Show(webcontent);
            }
            catch (System.Net.WebException E)
            {
                MessageBox.Show("Fail");
            }
        }
