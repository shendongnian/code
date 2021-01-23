    private List<SqlGeometry> SelectGeometries(string connectionString)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        var command = new SqlCommand(select shapeCol from MyTable, connection);
        connection.Open();
        List<SqlGeometry> geometries = new List<SqlGeometry>();
        SqlDataReader reader = command.ExecuteReader();
        if (!reader.HasRows)
        {
            return new List<SqlGeometry>();
        }
        while (reader.Read())
        {
            //approach 1: using WKB. 4100-4200 ms for hundred thousands of records
            //geometries.Add(SqlGeometry.STGeomFromWKB(new System.Data.SqlTypes.SqlBytes((byte[])reader[0]), srid).MakeValid());
            //approach 2: using WKB. 3220 ms for hundred thousands of records
            //geometries.Add(SqlGeometry.Deserialize(reader.GetSqlBytes(0))); 
            //approach 3: exception occur if you forget proper assembly redirection. 2565 ms for hundred thousands of records
            geometries.Add((SqlGeometry)reader[0]);
        }
        connection.Close();
        return geometries;
    }
