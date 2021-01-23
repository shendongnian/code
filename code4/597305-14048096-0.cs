    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("InsertCommand="INSERT INTO [Table] WeekOf,User,OtherData)
      VALUES (Convert(Date,@WeekOf,101), @User, @OtherData)"");
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("@WeekOf", WeekOfin.Text);
        cmd.Parameters.AddWithValue("@User", YourUser.Text);
        cmd.Parameters.AddWithValue("@OtherData", txtAddress.Text);
        ...
        ...
        connection.Open();
        try
        {
          cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          //MessageDlg.Show(ex.Message); //do what ever kind of logging or error trapping here that you want.. 
        }
        //You will need to explain how you are populating or getting
        // the MM/YY for WeekOf 
        //Personally I would refactor this code it's a bit unorthodox 
    }
 
