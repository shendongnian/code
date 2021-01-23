    var point = new ESRI.ArcGIS.Geometry.Point();
    point.PutCoords(1, 1);
    Console.WriteLine(point.GetType().FullName);
    Console.WriteLine(point.Envelope.GetType().FullName);
    Console.WriteLine(point.Envelope.ConvertToRCW().GetType().FullName);
