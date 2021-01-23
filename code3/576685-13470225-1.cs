    double d;
    TimeSpan ts;
    bool TruckisValidDouble = false;
    bool TruckisValidTimeSpan = TimeSpan.TryParse(dtTruck, CultureInfo.InvariantCulture, out ts);
    if(!TruckisValidTimeSpan)
    {
        TruckisValidDouble = double.TryParse(dtTruck, out d);
    }
    // use approapriate variables
