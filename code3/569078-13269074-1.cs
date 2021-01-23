    string responseCode = response.StatusCode.ToString();
    string responseStatusDescription = response.StatusDescription;
    
    StreamReader sr = new StreamReader(response.GetResponseStream());
    
    string result = sr.ReadToEnd();
    
    string[] parsed = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    
    List<string> str = parsed.ToList();
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    
    foreach (string s in str)
    
    {
        
    string[] ss = s.Split('=');
    
        if (ss.Count() == 2)
        {
            dictionary.Add(ss[0], ss[1]);
        }
        else
        {
            string value = "";
    
            for (int i = 0; i < ss.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                    {
                        break;
                    }
                    case 1:
                    {
                        value += ss[i];
                        break;
                    }
                    default:
                    {
    
                        value += "=" + ss[i];
    
                        break;
                    }
                }
            }
    
        dictionary.Add(ss[0], value);
        }
    }
