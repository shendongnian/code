    async Task<String> GetCurrencyCode() {
      using (var webClient = new WebClient()) {
        var xml = await webClient.DownloadStringTaskAsync("http://freegeoip.net/xml/");
        var xElement = XElement.Parse(xml);
        var countryName = (String) xElement.Element("CountryName");
        return await GetCurrencyCodeForCountry(countryName);
      }
    }
    
    async Task<String> GetCurrencyCodeForCountry(String countryName) {
      using (var webClient = new WebClient()) {
        var outerXml = await webClient.DownloadStringTaskAsync("http://www.webservicex.net/country.asmx/GetCurrencyByCountry?CountryName=" + countryName);
        var outerXElement = XElement.Parse(outerXml);
        var innerXml = (String) outerXElement;
        var innerXElement = XElement.Parse(innerXml);
        var currencyCode = (String) innerXElement.Element("Table").Element("CurrencyCode");
        return currencyCode;
      }
    }
