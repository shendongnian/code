    SelectElement TimeZoneSelect = new SelectElement(driver.FindElement(By.Name("time_zone")));
    IList<IWebElement> ElementCount = TimeZoneSelect.Options;
    int ItemSize = ElementCount.Count;
    
    for (int i = 0; i < ItemSize; i++)
    {
    	String ItemValue = ElementCount.ElementAt(i).Text;
    	Console.WriteLine(ItemValue);
    }
