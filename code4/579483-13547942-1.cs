            private void Form1_Load(object sender, EventArgs e)
        {
            //Setup connection to your database.
            SqlConnection myConnection = new SqlConnection("user id=sql_userID;" +
                                       "password=password;server=server_url;" +
                                       "Trusted_Connection=yes;" +
                                       "database=databaseName; " +
                                       "connection timeout=30");
            //Open connection.
            myConnection.Open();
            //Create dataset to store information.
            DataSet ds = new DataSet();
            //Create command object and adapter to retrieve information.
            SqlCommand  myCommand = new SqlCommand("SELECT * FROM Customers", myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
            adapter.Fill(ds);          
            //Loop through each row and display whichever column you wish to show in the CheckListBox.
            foreach (DataRow row in ds.Tables)
                checkedListBox1.Items.Add(row["ColumnNameToShow"]);
        }
