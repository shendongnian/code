    var cn = new SqlConnection("paste your code here");
    SqlCommand command = new SqlCommand(); 
    cmd.CommandText = "SELECT * FROM A WHERE mydate between '1/1/56 07:00:00' and '12/31/57 08:00:00'";
    cmd.Connection = cn;
 
    try
    {
        cn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            // up to you
        }
        reader.Close();
    }
    finally
    {
        cn.Close();
    }
