    int count = 0;
    if (dReader.HasRows) {
        while (dReader.Read()) {
            if(count == 1)  //add special row              
                gameweekList.Text += "something special " + dReader["gameweekID"].ToString();          
            else
                gameweekList.Text += "<div class=\"item\"><h4>Gameweek " + 
                (dReader["gameweekID"].ToString()) + "</h4></div>";
            count++;
        }
    } else {
        gameweekList.Text = "Error Finding Gameweeks";
    }
    dReader.Close();
    conn.Close();
