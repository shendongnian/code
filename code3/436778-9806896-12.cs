    public class Grabber
    {
        public event EventHandler<MyArgs> NotifyParentUI;
        // other code.....
        public string Request(string action)
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                return "";
            }
            HttpWebRequest req;
            string response = string.Empty;
            while (response.Equals(string.Empty) && proxy != null)
            {
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(action);
                    req.Proxy = proxy;
                    response = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
                }
                catch (Exception ex)
                {
                    RemoveProxy(proxy);
                    NotifyParentUI(this, new MyArgs() 
                       { Message = string.Format("Proxy Removed: {0}", proxy.Address.ToString()) });
                    proxy = GenNewProx();
                    NotifyParentUI(this, new MyArgs() 
                       { Message = string.Format("New Proxy: {0}", proxy.Address.ToString()) });
                }
            }
            return response;
        } 
    }
