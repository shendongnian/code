    public static void SaveFile(string name, string contentType, int size, byte[] data)
    {
	    using (SqlConnection connection = new SqlConnection())
	    {
		    OpenConnection(connection);
		    SqlCommand cmd = new SqlCommand();
		    cmd.Connection = connection;
		    cmd.CommandTimeout = 0;
		    string commandText = "INSERT INTO Files VALUES(@Name, @ContentType, ";
		    commandText = commandText + "@Size, @Data)";
		    cmd.CommandText = commandText;
		    cmd.CommandType = CommandType.Text;
		    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
		    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar, 50);
		    cmd.Parameters.Add("@size", SqlDbType.Int);
		    cmd.Parameters.Add("@Data", SqlDbType.VarBinary);
		    cmd.Parameters["@Name"].Value = name;
		    cmd.Parameters["@ContentType"].Value = contentType;
		    cmd.Parameters["@size"].Value = size;
		    cmd.Parameters["@Data"].Value = data;
		    cmd.ExecuteNonQuery();
		    connection.Close();
	    }
    }
    public static DataTable GetFileList()
    {
            DataTable fileList = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
 
                cmd.CommandText = "SELECT ID, Name, ContentType, Size FROM Files";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
 
                adapter.SelectCommand = cmd;
                adapter.Fill(fileList);
 
                connection.Close();
            }
 
            return fileList;
    }
    public static DataTable GetAFile(int id)
    {
            DataTable file = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
 
                cmd.CommandText = "SELECT ID, Name, ContentType, Size, Data FROM Files "
                    + "WHERE ID=@ID";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
 
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = id;
 
                adapter.SelectCommand = cmd;
                adapter.Fill(file);
 
                connection.Close();
            }
 
            return file;
    }
