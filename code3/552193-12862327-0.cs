      string yourConnectionString="";
        int result=0;
        using(OdbcConnection conn = new OdbcConnection(yourConnectionString))
        {
            
             string sql = "insert into company values(@CompName, @BusinessType, @Pword)";
             using (OdbcCommand cmd=new OdbcCommand(sql,conn))
             {   
                cmd.Parameters.AddWithValue("@CompName",txtCompName.Text);
                cmd.Parameters.AddWithValue("@BusinessType",DropDownList1.SelectedValue);  
                cmd.Parameters.AddWithValue("@Pword ",txtPassword.Text);  
                conn.Open();
                result=cmd.ExecuteNonQuery();
             }
             conn.Close();
             if(result >0)
             {
               txtCompName.Text = "";
               txtPassword.Text = "";
               DropDownList1.SeletedIndex = -1;
             }    
        }
