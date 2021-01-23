    var buses = from tblBuses in documentRoot.Descendants(ns + "MonitoredVehicleJourney")
                select new
                       {
                           LineName = tblBuses.Descendants(ns + "PublishedLineName").Single().Value,
                           AimedHours = tblBuses.Descendants(ns + "AimedDepartureTime").Single().Value,
                           ExpectedHours = tblBuses.Descendants(ns + "ExpectedDepartureTime").Select(el => el.Value).SingleOrDefault()
                       };
