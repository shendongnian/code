    string url = TxtUrl.Text;        
    string userkey = (string)ConfigurationSettings.AppSettings["userKey"];
    string version = (string)ConfigurationSettings.AppSettings["Version"];
    string countryKey=(string)ConfigurationSettings.AppSettings["CountryKey"];    
    strRequest.Append("<url>" + url + "</url>");
    strRequest.Append("<key>" + userkey + "</key>");
    strRequest.Append("<version>" + version + "</version>");
    strRequest.Append("<countryKey>" + countryKey + "</countryKey>");
