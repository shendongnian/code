    from item in xdoc.Descendants(ns + "body").Descendants(ns + "div").Descendants(ns + "p")
        select new TTMLElement
        {
            text = item,
            startTime = TimeSpan.Parse(item.Attribute("begin").Value),
            endTime = item.Attribute("dur") != null ?
              TimeSpan.Parse(item.Attribute("begin").Value).Add(TimeSpan.Parse(item.Attribute("dur").Value)) :
              TimeSpan.Parse(item.Attribute("end").Value)
       }
