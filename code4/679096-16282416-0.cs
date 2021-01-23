       private void addBtn_Click(object sender, RoutedEventArgs e)
    {
        SalesScreen ss = new SalesScreen();
        DataRowView drView = (DataRowView)dGrid.SelectedItem;
        String s = Convert.ToString(drView.Row["ID"]);
        String cmdString = "INSERT INTO tblCart(Title, GenreID, Price, Year, UML, Quantity)  Select Title, GenreID, Price, Year, UML, Quantity FROM tblMovies WHERE ID = " + s;
        SqlCommand cmd = new SqlCommand(cmdString, cn);
        cmd.CommandType = CommandType.Text;
        cn.Open();
        cmd.ExecuteNonQuery();
        ss.addtoList();
    }
