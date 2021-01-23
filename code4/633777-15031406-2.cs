    var location = RetrieveFormatedAddress(51.962146, 7.602304);
    string RetrieveFormatedAddress(double lat, double lon)
    {
        using (WebClient client = new WebClient())
        {
            string xml = client.DownloadString(String.Format(baseUri, lat, lon));
            return ParseXml(xml);
        }
    }
    private static string ParseXml(string xml)
    {
        var result = XDocument.Parse(xml)
                    .Descendants("formatted_address")
                    .FirstOrDefault();
        if (result != null)
            return result.Value;
        else
            return "No Address Found";
    }
