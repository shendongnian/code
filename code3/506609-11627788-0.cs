        protected void LoadCombo()
        {
 
               SqlConnection conn = new SqlConnection("Data Source=localhost;database=KnowledgeEssentials;Trusted_Connection=yes;connection timeout=30"); 
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Problem FROM PROBLEMT", conn); 
                DataSet ds = new DataSet(); 
                SqlDataAdapter ad = new SqlDataAdapter(); 
                ad.SelectCommand = new SqlCommand("SELECT Problem FROM PROBLEMT", conn); 
                ad.Fill(ds, "Problem"); 
                dataGridView1.DataSource = ds; 
                dataGridView1.DataBind(); 
            for (int X = 0; X <= ds.Tables[0].Rows.Count - 1; X++)
            { 
                comboBox1.Items.Add(ds.Tables[0].Rows[X]["Problem"].ToString()); 
            } 
