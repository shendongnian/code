    if (dReader.HasRows) {
        string previousRead = string.Empty;
        dReader.Read();
        previousRead = dReader["gameweekID"].ToString();
        while (dReader.Read()) {
              //use current and previous read 
              //dReader["gameweekID"].ToString()
              //previousRead
              //update previousRead for the next read
              previousRead = dReader["gameweekID"].ToString();
        }
    } else {
        gameweekList.Text = "Error Finding Gameweeks";
    }
    dReader.Close();
    conn.Close();
 
