    [WebMethod]
    public static string SendOnlineContacts(int ClientID)
    {
        string result="";
    string query = " Select fr.FRIEND_ID,cl.USER_NAME,cl.PROFILE_PIC "
                   +" from clients cl inner join friends fr on cl.CLIENT_ID =fr.FRIEND_ID "
                    +"  where fr.CLIENT_ID= "+ ClientID ;
    DataTable Dt= SQLHelper(SQLHelper.ConnectionStrings.WebSiteConnectionString).getQueryResult(query);
     if(Dt.Rows.Count>0)
      {
          for(int i=0;i<Dt.Rows.Count;i++)
        {
            result+=Dt.Rows[i][0]+","+Dt.Rows[i][1]+";" ;
        }
       return result;
       }
    }
