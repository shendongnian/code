    public void TestSO()
    {
        using (SqlConnection conexion = new SqlConnection())
        {
            using (SqlCommand command = new SqlCommand())
            {
                //This is the original multidimensional byte array
                byte[,] byteArray = new byte[2, 2] {{1, 0}, {0,1}};
                ConnectionStringSettings conString = ConfigurationManager.ConnectionStrings["ConnectionString"];
                conexion.ConnectionString = conString.ConnectionString;
                conexion.Open();
                command.Connection = conexion;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Table SET VarBinaryField = @Content WHERE Id = 73 ";
                command.Parameters.Add(new SqlParameter("@Content", SqlDbType.VarBinary, -1));
                //Serialize the multidimensional byte array to a byte[]
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, byteArray);
                //Set the serialized original array as the parameter value for the query
                command.Parameters["@Content"].Value = ms.ToArray();
                if (command.ExecuteNonQuery() > 0)
                {
                    //This method returns the VarBinaryField from the database (what we just saved)
                    byte[] content = GetAttachmentContentsById(73);
                    //Deserialize Content to a multidimensional array
                    MemoryStream ms2 = new MemoryStream(content);
                    byte[,] fetchedByteArray = (byte[,])bf.Deserialize(ms2);
                    //At this point, fetchedByteArray is exactly the same as the original byte array
                }
            }
        }
    }
