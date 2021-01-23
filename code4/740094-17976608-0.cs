    using(MySqlConnection sqlConn = new MySqlConnection("datasource=localhost;port=3306;username=admin;password=acw123"))
    {
        sqlConn.Open();
        using(MySqlCommand sqlCommand = new MySqlCommand("DELETE FROM tem_order WHERE temp_orderID = " + row["ID-column-name"],sqlConn))
        { 
            sqlCommand.ExecuteNonQuery();
        }
    }
