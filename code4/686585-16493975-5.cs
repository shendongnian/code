    // It's considered best practice to use a `using` block with `SqlConnection`
    // (among other objects). The `using` block ensures the connection is properly
    // disposed of once execution leaves the block.
    using (SqlConnection con = new SqlConnection(GetConnectionString()))
    {
        // I'm breaking into individual lines here simply 
        // so it's easier to read on SO
        string sql = "Insert INTO Requests (Priority, Module_ID, Day, 
                                            Start_Time, Length, Park, 
                                            Students, Room_Code, Status,
                                            Room_Allocated, Semester_ID,
                                            Week_1, Week_2, Week_3, Week_4,
                                            Week_5, Week_6, Week_7, Week_8,
                                            Week_9, Week_10, Week_11, Week_12,
                                            Week_13, Week_14, Week_15) 
                       OUTPUT INSERTED.Request_ID 
                       VALUES (@Priority, @Module_ID, @Day, @Start_Time, 
                               @Length, @Park, @Students, @Room_Code,
                               @Status, @Room_Allocated, @Semester_ID, 
                               @Week_1, @Week_2, @Week_3, @Week_4, @Week_5, 
                               @Week_6, @Week_7, @Week_8, @Week_9, @Week_10, 
                               @Week_11, @Week_12, @Week_13, @Week_14, @Week_15)";
        try
        {
            conn.Open();
            foreach (CSVFile entry in entries)
            {
        
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Priority", entry.Priority);
                    cmd.Parameters.AddWithValue("@Module_ID", entry.Module_ID);
                    cmd.Parameters.AddWithValue("@Day", entry.Day);
                    cmd.Parameters.AddWithValue("@Start_Time", entry.Start_Time);
                    // And so on
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        catch (FormatException ee)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Please enter a valid value');</SCRIPT>");
        }
        catch (System.Exception eeee)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('System Exception');</SCRIPT>");
        }
    } // Since we're in a `using` block, there is no need for the `finally` block 
      // close the connection.
