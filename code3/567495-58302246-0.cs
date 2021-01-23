System.NotSupportedException : This function can only be invoked from LINQ to Entities.
Therefore, what you can do is to make it valid using its WKT string and then convert that valid string toa DBGeometry like this:
public static DbGeometry MakeValid(DbGeometry geom)
{
     if (geom.IsValid)
          return geom;
     var wkt = SqlGeometry.STGeomFromText(new SqlChars(geom.AsText()), 0).MakeValid().STAsText().ToSqlString().ToString();
     return DbGeometry.FromText(wkt, 0);
}
