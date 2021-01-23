    private void updateData()
    {
        {
    
            SqlConnection c = new SqlConnection(c_string);
    
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FinalImages", c);
    
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            NumOfFiles = dt.Rows.Count;
            imgName = new string[NumOfFiles];
            for (int i = 0; i < NumOfFiles; i++)
            {
                imgName[i] = Convert.ToString(dt.Rows[i]["FinalImageName"]);
    
            } 
        }
    }
