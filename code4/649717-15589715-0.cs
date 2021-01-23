    if (dReader.HasRows) {
        while (dReader.Read()) {
            if ( dReader["gameweekID"].ToString() == currentWeekId ) 
            {    
                gameweekList.Text += "<div class=\"somethingSpecial\"><h4>Gameweek " + 
                (dReader["gameweekID"].ToString()) + "</h4></div>";
            } 
            else 
            {
                gameweekList.Text += "<div class=\"item\"><h4>Gameweek " + 
                (dReader["gameweekID"].ToString()) + "</h4></div>";
            }
        }
    } else {
        gameweekList.Text = "Error Finding Gameweeks";
    }
    dReader.Close();
    conn.Close();
