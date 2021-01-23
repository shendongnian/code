      public enum SqlCommandNames
        {
            spGetRace,
            spGetSes ,
            spGetOthers
        }
    
    public class myobj{
      public int id {get;set;}
      public string description {get;set}
    }
    public List<myobj> GetObj(SqlCommandNames sqlcmd)
            {
                List<myobj> objList = new List<myobj>();
                using (var con = new SqlConnection(this.ConnectionString))
                {
                    using (var cmd = new SqlCommand(sqlcmd.ToString(),con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            myobj r = new myobj();
                            r.id =  = reader.GetInt32(0); 
                            r.description = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            objList.Add(r);
                        }
                    }
                    return objList;
                }
            }
