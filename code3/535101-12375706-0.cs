    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        var connectionString = (ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        var updateCmd = "UPDATE [CarTab] SET Rent= 1 WHERE ([Model] = @Model)";
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            using(var command = new SqlCommand(updateCmd, connection))
            {
              command.Parameters.AddWithValue("@Model", value); //Replace with your value
    
              command.Connection.Open();
              command.ExecuteNonQuery();
            }
        }
    }
