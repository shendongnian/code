    ConnectionStringSettings pubs = ConfigurationManager.ConnectionStrings["RegConnectionString"];
        SqlConnection connection = new SqlConnection(pubs.ConnectionString);
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO CommentTable (Comment) values(@Text )";
    cmd.Parameters.AddWithValue("@Text", acommentarea.InnerText);
        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
