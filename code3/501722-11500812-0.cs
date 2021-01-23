    protected void Timer1_Tick(object sender, EventArgs e)
    {
       try
           {
            using (SqlConnection sqlConn =
                new SqlConnection("YourConnectionString"))
                {
                    sqlConn.Open();
                    Label1.Text = "Database Available";
    
    
                }
            }
        catch (Exception ex)
            {
                    Label1.Text = "Database Un-Available, " + "Possible Reason:"+ ex.Message;
            }
        }
