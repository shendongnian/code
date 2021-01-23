    DataTable dt = new DataTable();
        
        using(SqlConnection con = new SqlConnection(@"Data Source=CENTAUR09-PC\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=true"))
        {
           SqlCommand cmd = new SqlCommand("Select cust_name from customer", con); 
        
           SqlDataAdapter adapter = new SqlDataAdapter(cmd);
           adapter.Fill(dt);
         
           comboBox1.DataSource = dt.DefaultView; 
           comboBox1.DisplayMember = "/*datatable column name */"; 
        }
