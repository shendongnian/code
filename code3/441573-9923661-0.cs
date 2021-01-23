    private const string FetchTicketIdSql =
        "select Ticket_Id from tbl_Ticket where Client_EmailAdd = @Email";
    public int FetchTicketId()
    {
        // No need for ToString call...
        string connectionString =
            ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(connection, FetchTicketIdSql))
            {
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = 
                    bjNewTic_BAL.email;
                return (int) command.ExecuteScalar();
            }
        }
    }
