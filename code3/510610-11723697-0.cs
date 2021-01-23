        var adapter = new SqlDataAdapter();
        var dataSet = new DataSet();
        using(var connection = new SqlConnection(connetionString))
        {
            connection.Open();
            adapter.SelectCommand = new SqlCommand("Your query", connection);
            adapter.Fill(dataSet);
            connection.Close();
            
            //Print results  
            for (i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
            {
                MessageBox.Show(dataSet.Tables[0].Rows[1].ItemArray[1].ToString());
            }
        }
