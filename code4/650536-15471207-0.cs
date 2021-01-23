    DataSet ds =DataAccessLayer.ExeSelectQuery(sQuery);
                try
                {
    
      if(ds .Tables[0].Rows.Count>0)
                    {
      string sUserName = "";
                    string sPassword = "";
                     sUserName =   ds.Tables[0].Rows[0]["Username"].ToString();
                     sPassword =   ds.Tables[0].Rows[0]["Password"].ToString();
    sendMail( sUserName, sPassword);
                    } 
                }
