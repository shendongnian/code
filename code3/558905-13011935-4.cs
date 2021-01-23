    public List<State> GetStates()
    {
      List<State> stateList=new List<State>();
      // execute query, read from reader and add to the stateList
      // the below code is SqlServer DB specific.
      // you need to change the Connection,Command class for it to use with MySql.
       using (var con= new SqlConnection("replace your connection string"))
       {
          string qry="SELECT ID,NAME FROM STATES";
          var cmd= new SqlCommand(qry, objConnection);
          cmd.CommandType = CommandType.Text;           
          con.Open();
          using (var objReader = cmd.ExecuteReader())
          {
            if (objReader.HasRows)
            {
               while (objReader.Read())
               {
                 var item=new State();
                 item.ID=reader.GetInt32(reader.GetOrdinal("ID"));
                 item.Name=reader.GetString(reader.GetOrdinal("Name"));
                    
                 stateList.Add(item);
               }
             }
           }
        }
        return stateList;
    }
