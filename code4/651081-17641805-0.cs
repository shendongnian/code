    //Convert from SqlGeometry to DbGeometry 
    SqlGeometry sqlGeo = ...
    DbGeometry dbGeo = DbGeometry.FromBinary(sqlGeo.STAsBinary().Buffer);
    //Convert from DBGeometry to SqlGeometry
     SqlGeometry sqlGeo2 = SqlGeometry.STGeomFromWKB(new SqlBytes(dbGeo.AsBinary()), 0);
