    foreach (XElement stock in document.Descendants("stock"))
    {
        string ticker = (string)stock.Attribute("ticker");
        List<Double> pricetemp2 = new List<Double>();
        foreach (XElement price in stock.Descendants("price"))
        {
            double value = (double)price.Attribute("value");
            pricetemp2.Add(value);
        }
        groupList.Add(new PriceGroup(ticker, pricetemp2));
    }
