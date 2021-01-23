    WebClient wc = new WebClient();
    wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
    wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
    wc.Encoding = Encoding.UTF8;
    
    Parameters prms = new Parameters();
    prms.AddPair("email", email);
    prms.AddPair("password", password);
    
    wc.UploadStringAsync(new Uri(loginUrl), "POST", prms.FormPostData(), null);
    
    
    private void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
            // e.Result will contain the page's output
    }
    // This is my Parameters and Parameter Object classes
    public class Parameters
    {
    public List<ParameterObject> prms;
    
            public Parameters()
            {
                prms = new List<ParameterObject>();
            }
    
            public void AddPair(string id, string val)
            {
                prms.Add(new ParameterObject(id, val));
            }
    
            public String FormPostData()
            {
                StringBuilder buffer = new StringBuilder();
    
                for (int i = 0; i < prms.Count; i++)
                {
                    if (i == 0)
                    {
                        buffer.Append(System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                    }
                    else
                    {
                        buffer.Append("&" + System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                    }
                }
    
                return buffer.ToString();
            }
        }
    
    public class ParameterObject
    {
        public string id;
        public string value;
    
        public ParameterObject(string id, string val)
        {
            this.id = id;
            this.value = val;
        }
    }
