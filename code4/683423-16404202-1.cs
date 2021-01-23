    Location myLoc = new Location();
    myLoc.Coordinates = new Coordinates();
    myLoc.Coordinates.Latitude = 10;
    System.Diagnostics.Debug.WriteLine(myLoc.CoordinateLatitude.ToString());
    myLoc.Coordinates.Latitude = 20;
    System.Diagnostics.Debug.WriteLine(myLoc.CoordinateLatitude.ToString());
