    string connetionString = null;
    string sql = null;
    connetionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;" ;
    using(SqlConnection cnn = new SqlConnection(connetionString))
    {
       sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";
       cnn.Open();
       using(SqlCommand cmd = new SqlCommand(sql, cnn))
       {
           cmd.Parameters.AddWithValue("@first", textbox2.text);
           cmd.Parameters.AddWithValue("@last", textbox3.text);
           cmd.ExecuteNonQuery();
           MessageBox.Show ("Row inserted !! ");
       }
    }
