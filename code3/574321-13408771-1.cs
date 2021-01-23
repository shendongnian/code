    using System;
    using System.Net;
    using System.Xml;
    using System.Globalization;
    // ...    
    using (WebClient c = new WebClient())
    {
        string result = c.DownloadString(@"http://bankisrael.gov.il/currency.xml");
    	CultureInfo culture = new CultureInfo("en-US");
    	
    	XmlDocument xml = new XmlDocument();
    	xml.LoadXml(result);
    	
    	foreach (XmlNode currency in xml.SelectNodes("/CURRENCIES/CURRENCY"))
    	{
    		string name = currency.SelectSingleNode("NAME").InnerText;
    		int unit = int.Parse(currency.SelectSingleNode("UNIT").InnerText);
    		string currencyCode = currency.SelectSingleNode("CURRENCYCODE").InnerText;
    		string country = currency.SelectSingleNode("COUNTRY").InnerText;
    		double rate = double.Parse(currency.SelectSingleNode("RATE").InnerText, culture);
    		double change = double.Parse(currency.SelectSingleNode("CHANGE").InnerText, culture);
    		
    		Console.WriteLine("{2} {0} ({3}, {5}) rate:{1} change:{4}", currencyCode, rate, unit, country, change, name);
    	}
    }
