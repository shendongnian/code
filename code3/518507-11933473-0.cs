        string insertBooking = "INSERT INTO BookingDetails (EventID, NetworkID) values (@EventID, @NetworkID)";
        string selectCommand = "SELECT count(*) as UserBookings FROM BookingDetails WHERE NetworkID = @NetworkID AND EventID = @EventID";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            //Open DB Connection
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(selectCommand, conn))
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EventID", eventID);
                cmd.Parameters.AddWithValue("@NetworkID", NetworkID);
                if ((int)cmd.ExecuteScalar() == 0)
                {
                    SqlCommand cmd2 = new SqlCommand(insertBooking, conn);
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@EventID", eventID);
                    cmd2.Parameters.AddWithValue("@NetworkID", NetworkID);
                    cmd2.ExecuteNonQuery();
                }
            }
            //Close the connection
            conn.Close();
        }
