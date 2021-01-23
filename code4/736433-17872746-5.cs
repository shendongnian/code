    while (ListBox1.Items.Count>0)
    {
        var item =  ListBox1.Items[0].ToString();
    
        using (OracleCommand crtCommand = new OracleCommand("select count(*) from(( select * from all_ind_columns where  index_name= '" + item + "'  and table_owner='" + txtSrcUserID.Text.ToUpper() + "'))", conn1))
        using (OracleCommand ctCommand = new OracleCommand("select count(*) from(( select * from all_ind_columns where  index_name= '" + item + "'  and table_owner='" + txtDesUserID.Text.ToUpper() + "'))", conn1))
        {
            string result1 = crtCommand.ExecuteScalar().ToString();
            string result2 = ctCommand.ExecuteScalar().ToString();
            if (result1 != result2)
            {
                ListBox2.Items.Add(item);
            }
            ListBox1.Items.RemoveAt(0);
        }   
                     
    }
