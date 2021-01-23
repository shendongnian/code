        using System.Data;
        using System;
        using MySql.Data.MySqlClient;`enter code here`
        
     //   this is the part you will need for your method`enter code here`
        private void BtnInsert_Click(object sender, EventArgs e)
            {
        MySqlConnection con = new MySqlConnection("Server=yourdomainname.com;Port=3306;database=your_database_name;User Id=yourMySQLuserName;Password=yourpassword;charset=utf8");
        
                    try
                    {
                        
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                            
                           txtSysLog.Text = "Successfully connected";
                           
                        }
                        
        
                    }catch(MySqlException ex)
                    {
                        txtSysLog.Text = ex.ToString();
        
        
                    }finally
                    {
                        con.Close();
                    }
    
    }
