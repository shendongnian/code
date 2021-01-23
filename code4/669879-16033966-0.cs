    public static int Main() 
    {
           /* Adds the event and the event handler for the method that will 
              process the timer event to the timer. */
           myTimer.Tick += new EventHandler(TimerEventProcessor);
    
           // Sets the timer interval to 5 seconds.
           myTimer.Interval = 5000;
           myTimer.Start();
    
    }
    //Function called every half second
    private void TimerEventProcessor(object sender, EventArgs e) 
    { 
        //Update the dataBase every half second
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(command, connection);
            MytextBox.Text = sqlCommand.ExecuteScalar();
            connection.Close();
            connection.Close();
        }
    } 
