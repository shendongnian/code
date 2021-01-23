    string imageName; 
    string description; 
    string path; 
    int priority;
    //(snip) populate the variables
    const string query = "Update imagesTable set Priority = Priority + 1 where Priority >= @Priority;" +
                   "insert into imagesTable (ImageName, Description, Path, Priority) values (@ImageName, @Description, @Path, @Priority)";
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand(query, connection))
    {
        connection.Open();
        
        command.Parameters.AddWithValue("@ImageName", imageName);
        command.Parameters.AddWithValue("@Description", description);
        command.Parameters.AddWithValue("@Path", path);
        command.Parameters.AddWithValue("@Priority", priority);
        command.ExecuteNonQuery();
    }
