    { 
    
        SqlConnection con =new SqlConnection("Data Source=Server_Name;Initial Catalog=Database_Name;integrated security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        private void CashMemoForm_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Column_Name From Table_Name", con);
            dr = cmd.ExecuteReader();
           while (dr.Read())
            
            {
                comboBox1.Items.Add(dr[0]).ToString();
            }
        }
    }
