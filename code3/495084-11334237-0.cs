    public void TestSO()
    {
        using (SqlConnection conexion = new SqlConnection())
        {
            using (SqlCommand comando = new SqlCommand())
            {
                byte[,] byteArray = new byte[2, 2] {{1, 0}, {0,1}};
                ConnectionStringSettings conString = ConfigurationManager.ConnectionStrings["CSEVENTOSDB"];
                conexion.ConnectionString = conString.ConnectionString;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE Table SET VarBinaryField = @Content WHERE Id = 73 ";
                comando.Parameters.Add(new SqlParameter("@Content", SqlDbType.VarBinary, -1));
                //Serialize the multidimensional byte array to a byte[]
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, byteArray);
                //Set the serialized original array as the parameter for the query
                comando.Parameters["@Content"].Value = ms.ToArray();
                if (comando.ExecuteNonQuery() > 0)
                {
                    //This method returns the field Content from the database. This is, what we just saved.
                    byte[] content = ObtenerContenidoDeUnAdjunto(73);
                    //Deserialize Content to a multidimensional array
                    MemoryStream ms2 = new MemoryStream(contenido);
                    byte[,] fetchedByteArray = (byte[,])bf.Deserialize(ms2);
                    //At this point, fetchedByteArray is exactly the same as the original buteArray
                }
            }
        }
    }
