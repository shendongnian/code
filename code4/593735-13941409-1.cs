    public string Cardinal(double degrees)
    {
        if (degrees > 315.0 || degrees < 45.0)
        {
            return "N";
        }
        else if (degrees >= 45.0 && degrees < 90)
        {
            return "E";
        }
        // Etc for the whole 360 degrees.  Segment finer if you want NW, WNW, etc.
    }
