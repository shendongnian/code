    private static double GetPrice(XElement retail, string priceElement)
    {
        // short circuting will stop as soon as the statement is false
        if (retail != null && retail.Element(priceElement) != null)
        {
            return Convert.ToDouble(retail.Element(priceElement).Value);
        }
        return 0.0;
    }
