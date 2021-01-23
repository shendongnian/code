            string s = "Central Time (US & Canada)";
           
            s = System.Web.HttpUtility.UrlEncode(s,System.Text.Encoding.ASCII);
            s = System.Web.HttpUtility.UrlEncode(s, System.Text.Encoding.ASCII);
            s = s.Replace("-","%2D");
            s = s.Replace("_","%5F");
            s = s.Replace("!","%21");
            s = s.Replace("*","%2A");
            s = s.Replace("(","%28");
            s = s.Replace(")","%29");
            s = System.Web.HttpUtility.UrlEncode(s, System.Text.Encoding.ASCII);
            
            if (s.ToLower() == "Central%252BTime%252B%2528US%252B%252526%252BCanada%2529".ToLower())
            {
                System.Diagnostics.Debug.WriteLine("Success");
            }
