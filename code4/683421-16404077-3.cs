    public double CoordinateLongitude
    {
        get { return (this.Coordinates.Longitude); }
        set {
            Coordinate temp = this.Coordinates;
            temp.Longitude = value;
            this.Coordinates = temp;
        }
    }
