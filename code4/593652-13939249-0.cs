    ...
    myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
    myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
    var doc = XDocument.Load(myHttpWebResponse.GetResponseStream());
    var country = doc.Descendants("countryName").First().Value;
    var city = doc.Descendants("city").First().Value;
    Console.WriteLine(country + " - " + city);
    ...
