	protected void DisplayCurrency()
	{
		var currency = Cache["Currency"] as Dictionary<string, List<Currency>>;
		if (currency == null)
		{
			currency = new Dictionary<string,List<Currency>>();
			var xmlDoc = XElement.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
			if (xmlDoc != null)
			{
				var queryXML = from xml in xmlDoc.Elements("Currency")
							   where (string)xml.Attribute("Kod") == "USD" || (string)xml.Attribute("Kod") == "EUR"
							   select xml;
				if (queryXML != null)
				{
					//fill Dictionary with data
					foreach (var item in queryXML)
					{
						currency.Add(item.Attribute("Kod").Value, new List<Currency> 
						{
							 new Currency 
							 {     
								 ForexBuying    = item.Element("ForexBuying").Value,
								 ForexSelling   = item.Element("ForexSelling").Value, 
								 BanknoteBuying = item.Element("BanknoteBuying").Value,
								 BanknoteSelling= item.Element("BanknoteSelling").Value
							 }
						});
					}
				}
			}
			Cache["Currency"] = currency;
		}
		foreach (var item in currency)
		{
			switch (item.Key)
			{
				case "USD":
					litUSDtxt.Text = item.Key;
					foreach (var i in item.Value)
					{
						litUSD.Text = i.BanknoteSelling;
					}
					break;
				case "EUR":
					litEURtxt.Text = item.Key;
					foreach (var i in item.Value)
					{
						litEUR.Text = i.BanknoteSelling;
					}
					break;
			}
		}
	}
