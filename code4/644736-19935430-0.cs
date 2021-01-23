    // my object to be persisted using NHibernate
    var myObj = new MyObj();
    // add polygon of type GeoAPI.Geometries.IGeometry
    myObj.CoveredArea = myGeoFactory.CreatePolygonArea(/* ... */);
    // use NHibernate to save my obj
    sessioNScope.Save(myObj); // <- throws NotSupportedException here
