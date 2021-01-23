    string formatted = "";
    using (WebClient wc = new WebClient())
    {
        string raw = wc.DownloadString(new Uri(requestUri));
        var xmlElm = XElement.Parse(raw);
        var status = (from elm in xmlElm.Descendants()
            where elm.Name == "status"
            select elm).FirstOrDefault();
        if (status.Value.ToLower() == "ok")
        {
            var res = (from elm in xmlElm.Descendants()
                where elm.Name == "formatted_address"
                select elm).FirstOrDefault();
            formatted = res.Value;
        }
        else
        {
             formatted = "Bad status: " + status.Value;
        }
    }
    //use the variable as you wish...
