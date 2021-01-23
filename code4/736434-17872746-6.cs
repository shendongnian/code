    while (ListBox1.Items.Count>0)
    {
        var item =  ListBox1.Items[0].ToString();
    
        using (OracleConnection con = new OracleConnection(connectionString))
        using (OracleCommand cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "select count(*) from(( select * from all_ind_columns where  index_name= :item  and table_owner=:table_owner))";
            cmd.Parameters.Add(item);
            cmd.Parameters.Add(txtSrcUserID.Text.ToUpper());
    
            string result1 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            cmd.Parameters.Add(item);
            cmd.Parameters.Add(txtDesUserID.Text.ToUpper());
            string result2 = cmd.ExecuteScalar().ToString();
    
            if (result1 != result2)
            {
                ListBox2.Items.Add(item);
            }
            ListBox1.Items.RemoveAt(0);
        }
                 
    }
