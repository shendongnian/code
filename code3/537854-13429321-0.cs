    public double GetDistanceTo(GeoCoordinate other)
    {
        if (double.IsNaN(this.Latitude) || double.IsNaN(this.Longitude) || double.IsNaN(other.Latitude) || double.IsNaN(other.Longitude))
        {
            throw new ArgumentException(SR.GetString("Argument_LatitudeOrLongitudeIsNotANumber"));
        }
        else
        {
            double latitude = this.Latitude * 0.0174532925199433;
            double longitude = this.Longitude * 0.0174532925199433;
            double num = other.Latitude * 0.0174532925199433;
            double longitude1 = other.Longitude * 0.0174532925199433;
            double num1 = longitude1 - longitude;
            double num2 = num - latitude;
            double num3 = Math.Pow(Math.Sin(num2 / 2), 2) + Math.Cos(latitude) * Math.Cos(num) * Math.Pow(Math.Sin(num1 / 2), 2);
            double num4 = 2 * Math.Atan2(Math.Sqrt(num3), Math.Sqrt(1 - num3));
            double num5 = 6376500 * num4;
            return num5;
        }
    }
