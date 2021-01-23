    TimeSpan ts;
    bool TruckisValid = TimeSpan.TryParse(dtTruck, CultureInfo.InvariantCulture, out ts);
    bool PlaneisValid = TimeSpan.TryParse(dtPlane, out ts);
    if (TruckisValid )
    {
        truck = TimeSpan.FromDays(Convert.ToDouble(dtTruck));
    }
    else if (PlaneisValid)
    {
        plane = TimeSpan.FromDays(Convert.ToDouble(dtPlane));
    }
    else
    {
    }
