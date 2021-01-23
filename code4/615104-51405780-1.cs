    // --> Prototype : https://ctrader.guru/?id=1#reload
        
        public static string AddGetParamToUrl(string url, string pname, string pvalue)
        { 
            pvalue = Uri.EscapeDataString(pvalue);
            if (url.IndexOf("?") > -1)
            {
        
                url = url.Replace("?", string.Format("?{0}={1}&", pname, pvalue));
        
            }
            else if (url.IndexOf("#") > -1)
            {
        
                url = url.Replace("#", string.Format("?{0}={1}#", pname, pvalue));
        
            }
            else
            {
        
                url = string.Format("{0}?{1}={2}", url, pname, pvalue);
        
            }
        
            return url;
        
        }
