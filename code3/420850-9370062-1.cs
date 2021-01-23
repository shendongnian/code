            SqlCommand myCommand = new SqlCommand(); //The command you intend to pass to SQL
            DataSet myDataSet = new DataSet(); //The Dataset you'll fill and retrieve info from
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.yourConnectionString); // I prefer my connection string to be in my project's properties. Don't put sensitive info like passwords here though
            myCommand.CommandType = CommandType.Text; // In this case we're using a text command, not stored procedure.  That means you're typing out your command, as a string, in c# (next line)
            myCommand.CommandText = "SELECT * FROM Animals_Table WHERE Type=@Type"; // @ denotes a parameter, in this case named Type
            myCommand.Parameters.AddWithValue("Type", "Mammal");
            myConnection.Open();
            Command.Connection = myConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(myDataSet);
            // Now you can use the data you've retrieved (your DataSet)
            textboxReturnedAnimalName1.Text = myDataSet.Tables[0].Rows[0]["Name"]; //You want the Name field from SQL
