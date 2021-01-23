    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand com = new SqlCommand("Select * from mytable", conn);
        DataReader reader = com.ExecuteReader();
    
        using (TextWriter writer = new TextWriter("myFile.txt"))
        {
            while (reader.Read())
            {
                StringBuilder myData = new StringBuilder();
                myData.Append(reader["Fname"].ToString();
                //etc - see how you want to format it
    
                writer.WriteLine(myData.ToString());
            }
        }
    }
