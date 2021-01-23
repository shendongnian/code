    foreach (XmlNode driver in drivers)
    {
      dInfo = new BusObjects.DriverInfo();
      
      if (driver.ChildNodes[i].Name.Equals("BestLapTime"))
      {
        dInfo.FastestLap = Convert.ToDouble(driver.ChildNodes[i].InnerText);
      }
    }
    
    // you can use an auto property for FastestLap
    public double FastestLap {get; set;}
    
    // Add another property for FormattedFastestLap:
    public string FormattedFastestLap 
    {
    	get { return TimeSpan.FromSeconds(FastestLap).ToString(@"mm\:ss\.fff"); }
    }
