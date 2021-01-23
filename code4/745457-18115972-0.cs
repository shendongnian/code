    var deliveryTime = doc.Root.Descendants(ns + "SERVICEUPGRADES")
        .SingleOrDefault(c => (string)c.Element(ns + "DELIVERYTIME") == "before 3:30 PM");
    if(deliveryTime != null)
    {     
        var costnode6 = deliveryTime.Element(ns + "TOTAL_COST");
        var cost6 = (decimal)costnode6;   
    }
