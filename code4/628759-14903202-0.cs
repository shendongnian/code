    public String getLocation()
    {
        return RetrieveFormatedAddress(latitude, longitutde);
    }
    
    static string RetrieveFormatedAddress(string lat, string lng)
    {
        string requestUri = string.Format(baseUri, lat, lng);
    
        using (WebClient wc = new WebClient())
        {
            var result = wc.DownloadString(new Uri(requestUri));
            var xmlElm = XElement.Parse(result);
            var status = (from elm in xmlElm.Descendants()
                  where elm.Name == "status"
                  select elm).FirstOrDefault();
            if (status.Value.ToLower() == "ok")
            {
            var res = (from elm in xmlElm.Descendants()
                   where elm.Name == "formatted_address"
                   select elm).FirstOrDefault();
                return res.Value;
            }
            else
            {
                return "No Address Found";
            }
        }
    }
