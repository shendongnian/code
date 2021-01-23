      if (Session["para1"] != null) 
        {
          int AgentCode = Convert.ToInt32(Session["para1"].ToString());
        
          //Search by AgentCode 
               GridView1.DataSource = ws.GetJobsByAgencyID(AgentCode );
                GridView1.DataBind();
        
        }
       else if (Session["para2"] != null)
        {
          string title = Session["para1"].ToString();
    
           //Search by title
           GridView1.DataSource = ws.GetJobsByAgencyID(title );
            GridView1.DataBind();
        }
       else
       {
          // your default parameters
        }
