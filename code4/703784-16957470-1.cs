    private void button1_Click(object sender, EventArgs e) 
    {
        SqlDataReader reader = null;
    
        //Corrections
        DataTable table = new DataTable(); //#1 : Initialize Table
        
        using(SqlConnection sqlConnection1 = new SqlConnection()) //#2: Initialize SqlConnection & make use of `using` for object cleanup after use
        using(SqlCommand sqlCommand1 = new SqlCommand()) //#3: Initialize SqlCommand & make use of `using` for object cleanup after use
        {
            
            sqlConnection1.ConnectionString = "<connection string>"; //#4: Set connection string
            sqlCommand1.Connection = sqlConnection1;
            sqlConnection1.Open();
                        
            sqlCommand1.CommandText = "SELECT id,parola FROM ANGAJAT WHERE id='@user' AND parola='@pass'";
            
            sqlCommand1.Parameters.AddWithValue("@user",textBox1.Text);
            sqlCommand1.Parameters.AddWithValue("@pass",textBox2.Text);
    
            using(SqlReader reader = sqlCommand1.ExecuteReader()) //#4 : Make use of `using` for object cleanup after use
            {
                table.Load(reader);  
            }
            
            sqlConnection1.Close();
        }
    }
