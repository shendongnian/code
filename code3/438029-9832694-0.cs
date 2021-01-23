    using System.Xml.Linq;
    
    IEnumerable<XElement> prices = from t in doc.Root.Descendants("EUR");
        foreach (XElement t in prices)
        {
            string priceInEUR = t.Value;
        }
