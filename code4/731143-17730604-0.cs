            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
    			SqlCommand cmd = new SqlCommand(sqlcmd, conn);
    
                cmd.Parameters.AddWithValue("@Manufacture", manu);
    
                SqlDataReader dr = cmd.ExecuteReader();
    			
    			IList<string> modelList = new List<string>()
    			while (dr.Read())
    			{
    				modelList.add(dr[0].ToString());
    			}
    			
                ModelComboBox.DataSource = modelList;
            }
