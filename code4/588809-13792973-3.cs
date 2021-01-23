     public string ValidateRole(string sUsername)
       {
    
           string matchstring = "SELECT  roleid FROM tblUserRoles WHERE UserName='" +      sUsername +"'";
           SqlCommand cmd = new SqlCommand(matchstring);
           cmd.Connection = new SqlConnection("Data Source=(local);Initial Catalog=samplename;Integrated Security=True");
           cmd.Connection.Open();
           cmd.CommandType = CommandType.Text;
    
           SqlDataAdapter sda = new SqlDataAdapter();
           DataTable dt = new DataTable();
           sda.SelectCommand = cmd;
           sda.Fill(dt);
    
           string match = "fail";
        if (dt.Rows.Count > 0)
        {
           foreach (DataRow row in dt.Rows)
           {
               match = row["roleid"].ToString();
            return match;
           }              
    
        }  
        return "fail";
       }
