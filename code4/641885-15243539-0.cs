    from x in doc.Descendants("Event")
    select new Event() {
        Id = x.Attribute("Id").Value,
        StartTimeCollection = new Collection<StartTime>(
            x.Descendants("StartTimes").SelectMany(
                startTimes => startTimes.Elements("StartTime").Select(
                    startTime => new StartTime() {
                        Start = startTime.Attribute("Time").Value,
                        Monday = Boolean.Parse(startTime.Attribute("Mon").Value),
                        Tuesday = Boolean.Parse(startTime.Attribute("Tue").Value),
                        Wednesday = Boolean.Parse(startTime.Attribute("Wed").Value),
                        Thursday = Boolean.Parse(startTime.Attribute("Thu").Value),
                        Friday = Boolean.Parse(startTime.Attribute("Fri").Value),
                        Saturday = Boolean.Parse(startTime.Attribute("Sat").Value),
                        Sunday = Boolean.Parse(startTime.Attribute("Son").Value)
                    })).ToList())
    }
