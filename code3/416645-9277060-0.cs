    public void insertRows()
    {
     if (Users.Count > 0)
     {
      OracleTransaction trans=_conn.BeginTransaction();
      try
      {
       // create insert statement with bind vars
       Stringbuilder sb = new Stringbuilder();
       sb.Append("INSERT into sbx_staging_user(");
       sb.Append("client,");
       sb.Append("username,");
       sb.Append("user_id");
       sb.Append(") VALUES (");
       sb.Append(":client,");
       sb.Append(":username,");
       sb.Append("seq_user_id.nextval");
       sb.Append(") ");
     
       OracleCommand cmd = new OracleCommand(sb.ToString(), _conn);
    
       string[] ary_client = new string[Users.Count];
       string[] ary_username = new string[Users.Count];
    
       for (int i=0; i<Users.Count; i++)
       {
        User row=Users[i];
        ary_client[i]=row.client;
        ary_username[i]=row.username;
       }
       // prepare bind vars(bind in bulk using arrays)
       OracleParameter prm=new OracleParameter();
       cmd.Parameters.Clear();
       cmd.ArrayBindCount=Users.Count;
       cmd.BindByName=true;
    
       prm=new OracleParameter("client", OracleDbType.Varchar2); prm.Value=ary_client; cmd.Parameters.Add(prm);
       prm=new OracleParameter("username", OracleDbType.Varchar2); prm.Value=ary_username; cmd.Parameters.Add(prm);
       
       cmd.ExecuteNonQuery();
       trans.Commit();
       trans.Dispose();
      }
      catch {
       trans.Rollback();
       trans.Dispose();
       throw;
      }
     }
    }
