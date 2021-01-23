            SqlCommand myCommand = new SqlCommand(); //The command you intend to pass to SQL
            DataSet myDataSet = new DataSet(); //The Dataset you'll fill and retrieve info from
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.yourConnectionString); // I prefer my connection string to be in my project's properties. Don't put sensitive info like passwords here though
            myCommand.CommandType = CommandType.Text; // In this case we're using a text command, not stored procedure.  That means you're typing out your command, as a string, in c# (next line)
            myCommand.CommandText = "SELECT * FROM Animals_Table WHERE Type=@Type"; // @ denotes a parameter, in this case named Type
            myCommand.Parameters.AddWithValue("Type", "Mammal"); //You can also do Add instead of AddWithValue - this lets/forces you to input the type information manually.  It's more of a pain, but can resolve problems if c# doesn't make right assumptions
            myConnection.Open();  // Open your connection
            Command.Connection = myConnection;  // Plug that connection into your command
            SqlDataAdapter adapter = new SqlDataAdapter(Command); // Plug that command into a data adapter
            adapter.Fill(myDataSet); // populate your DataSet
            // Now you can use the data you've retrieved (your DataSet)
            textboxReturnedAnimalName1.Text = myDataSet.Tables[0].Rows[0]["Name"]; //You want the Name field from SQL, for the first table returned, and the first row in that table
