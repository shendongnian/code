    XNamespace ns = "http://www.siri.org.uk/";
    
    List<DateTime> departureTimes = doc.Descendants(ns + "ServiceDelivery")
       .Elements(ns + "StopMonitoringDelivery")
       .Elements(ns + "MonitoredStopVisit")
       .Elements(ns + "MonitoredVehicleJourney")
       .Elements(ns + "MonitoredCall")
       .Elements(ns + "ExpectedDepartureTime")
       .Select(x => (DateTime)x)
       .ToList();
