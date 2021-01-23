    public Coordinates Coordinates { get; set; }
        
    public double CoordinateLatitude
    {
      get { return (this.Coordinates.Latitude); }
      set { this.Coordinates.Latitude = value;}
    }
