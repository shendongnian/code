    private void AltitudeThreadWork()
    {
        var updated = DateTime.Now;
    
        bool above = Aircraft.Altitude > AltitudeChange.Altitude;  // Determine if it is a climbing or a descent
       
        while (!((Aircraft.Altitude > AltitudeChange.Altitude) ^ above))  // Check if it is in the other side of the plane defined by Altitude 
        // (because altitude is a continuous function, if it is on the other "side" it means it has crossed the given altitude)
        {
            UpdateAltitude((DateTime.Now - updated).TotalMilliseconds);
            updated = DateTime.Now;
            Thread.Sleep(40);
        }
        Aircraft.Altitude = AltitudeChange.Altitude;  // Altitude is reached
    }
