        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\MSI\Documents\Visual Studio 2010\Projects\Baza z własnymi batonami\Baza z własnymi batonami\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cn.Open();
        cmd.CommandText = "SELECT oddal FROM TableName WHERE (Your = Condition)";
        dr = cmd.ExecuteReader();
        if dr.Read()
        {
                if dr("oddal")
                {
                //Set picture box to image 1
                } 
                else 
                { //Set picture box to image 1
                }
        }
        cn.Close();
