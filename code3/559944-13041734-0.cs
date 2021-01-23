    string output = string.Empty;
        
        string httpHost = Request.ServerVariables["HTTP_HOST"];
        string url = Request.ServerVariables["URL"];
        string[] splitUrl = url.Split('/');
        for (int i = 0; i < splitUrl.Length -1; i++)
        {
            if (splitUrl[i].Length > 0)
            {
                output += string.Format("/{0}", splitUrl[i]);
            }
        }
        string ssl = "http://";
        if (Request.ServerVariables["HTTPS"] == "off")
        {
            ssl = "https://";
        }
        output = string.Format("{0}{1}{2}/", ssl, httpHost, output);
