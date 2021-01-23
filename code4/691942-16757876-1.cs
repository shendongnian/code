    public static DbGeometry geoMakeValid(DbGeometry geom)
          {
    
              EntityConnection Connec = getConnection();
    
              DbCommand com = Connec.StoreConnection.CreateCommand();
              com.CommandText = "select dbo.GeomMakeValid(@geom)";
              com.CommandType = System.Data.CommandType.Text;
              com.Parameters.Add(new SqlParameter("@geom", geom.AsText()));
              if (com.Connection.State == ConnectionState.Closed) com.Connection.Open();
              try
              {
                  var result = com.ExecuteScalar(); // should properly get your value
                  Connec.Close();
                  return DbGeometry.FromText( result.ToString(),geom.CoordinateSystemId);
                  
              }
              catch (System.Exception e)
              {
              }
              Connec.Close();
              return geom;
          }
