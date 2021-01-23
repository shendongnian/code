    protected void ListOfAvailableEvents_GrivView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int numberOfBookings = 0;
        int numberOfAvailableSeats = 0;
        string connString = "Data Source=appServer\\sqlexpress;Initial Catalog=EventRegMgnSysDB;Integrated Security=True;";
        string selectCommand = @"SELECT     COUNT(*) AS UserBookingsCount, dbo.Events.NumberOfSeats
                                    FROM         dbo.BookingDetails INNER JOIN
                                                          dbo.Events ON dbo.BookingDetails.EventID = dbo.Events.ID
                                    GROUP BY dbo.Events.NumberOfSeats";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            //Open DB Connection
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(selectCommand, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                    if (reader.Read())
                    {
                        numberOfBookings = Int32.Parse(reader["UserBookingsCount"].ToString());
                        numberOfAvailableSeats = Int32.Parse(reader["NumberOfSeats"].ToString());
                    }
            }
            //Close the connection
            conn.Close();
        }
     if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            LinkButton lnkTitle = (LinkButton )e.Row.FindControl("lnkTitle");
         
            
             if (numberOfBookings >= numberOfAvailableSeats)
            {
               
                lnkTitle.Visible = false;
            }
            else
            {
               
                lnkTitle.Visible = true;
            }
            
        }
