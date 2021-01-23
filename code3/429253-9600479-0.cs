     SqlConnection con1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con2"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from table1", con1);
        SqlDataReader dr;
        con1.Open();
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
        while (dr.Read())
        { 
      //  ....
        }dr.Close()
       //your condition then fire insert commnd with connection con2 
       
        SqlCommand insertcmd = new SqlCommand("insert into table2", con2);
        SqlDataAdapter dap = new SqlDataAdapter(insertcmd);
   //     ...
