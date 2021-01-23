    public void btnSearch_Click(object sender, EventArgs e)
        {
    	
    	 BindData();
    	    
        }
    	Private xxx BindData()
    	{
    	 if(Viewstate[txt] !==null)
    		 {
    		  string WhereCl= GetWhereClause(txt);
    		 }
            string query = "select * from Ressources";
             if(!string.IsNullOrEmpty(WhereCl))
           { 
             query =query + WhereCl;
           }		 
            SqlCommand cmd = new SqlCommand(query);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
    	}
    	
    	Private string GetWhereClause(string txt)
    	{
    	  string where  = where data like'%" + txt+ "%'";
    	}
