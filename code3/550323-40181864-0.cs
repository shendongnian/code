    using SharpKml.Dom;
    using SharpKml.Engine;
    using SharpKml.Dom.GX;
    TextReader reader = File.OpenText(filePath);
    KmlFile file = KmlFile.Load(reader);
    _kml = file.Root as Kml;
    sPlaceMarks[] tempPlaceMarks = new sPlaceMarks[1000];
    if (_kml != null)
    {
      foreach (var placemark in _kml.Flatten().OfType<Placemark>())
      {
      tempPlaceMarks[numOfPlaceMarks].Name = placemark.Name;
      tempPlaceMarks[numOfPlaceMarks].Description = placemark.Description.Text;
      tempPlaceMarks[numOfPlaceMarks].StyleUrl = placemark.StyleUrl;
      tempPlaceMarks[numOfPlaceMarks].point = placemark.Geometry as SharpKml.Dom.Point;
      tempPlaceMarks[numOfPlaceMarks].CoordinateX = tempPlaceMarks[numOfPlaceMarks].point.Coordinate.Longitude;
      tempPlaceMarks[numOfPlaceMarks].CoordinateY = tempPlaceMarks[numOfPlaceMarks].point.Coordinate.Latitude;
      tempPlaceMarks[numOfPlaceMarks].CoordinateZ = tempPlaceMarks[numOfPlaceMarks].point.Coordinate.Altitude;
      numOfPlaceMarks++;
      }
      foreach (var lookAt in _kml.Flatten().OfType<LookAt>())
      {
      Placemark placemark = (Placemark)lookAt.Parent;
      for (int i = 0; i < numOfPlaceMarks; i++)
      {
        if (placemark.Name == tempPlaceMarks[i].Name)
        {
          tempPlaceMarks[i].Name = placemark.Name;
          tempPlaceMarks[i].Description = placemark.Description.Text;
          tempPlaceMarks[i].StyleUrl = placemark.StyleUrl;
          tempPlaceMarks[i].altitude = lookAt.Altitude;
          tempPlaceMarks[i].AltitudeMode =(SharpKml.Dom.GX.AltitudeMode)lookAt.GXAltitudeMode;
          tempPlaceMarks[i].Heading = lookAt.Heading;
          tempPlaceMarks[i].Latitude = lookAt.Latitude;
          tempPlaceMarks[i].Longitude = lookAt.Longitude;
          tempPlaceMarks[i].Range = lookAt.Range;
          tempPlaceMarks[i].Tilt = lookAt.Tilt;
          break;
        }
      }
    }
