    public int select_TicketId()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        int result = -1;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select TOP 1 Ticket_Id from tbl_Ticket where Client_EmailAdd=@email";
            command.Parameters.Add("@email", SqlDbType.Text).Value = objNewTic_BAL.email;
            result = Convert.ToInt32(command.ExecuteScalar());
        }
    
        return result;
    }
