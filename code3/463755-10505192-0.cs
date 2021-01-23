    DateTime start = DateTime.Today;
    // We'll use this as an *exclusive* upper bound
    DateTime end = start.AddDays(3);
    var query = from c in loadedCustomData.Descendants("PrayerTime")
                let bonn = Bønn.FromXElement(c)
                where bonn.Dato >= start && bonn.Dato < end;
                select bonn;
