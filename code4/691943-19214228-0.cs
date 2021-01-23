    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Types;
    
    namespace System.Data.Spatial
    {
        public static class DbGeometryExtension
        {
            public static DbGeometry MakeValid(this DbGeometry geom)
            {
                if (geom.IsValid)
                    return geom;
    
                return DbGeometry.FromText(SqlGeometry.STGeomFromText(new SqlChars(geom.AsText()), 4326).MakeValid().STAsText().ToSqlString().ToString(), 4326);
    
            }
        }
    }
