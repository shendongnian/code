    List<string> addresses=new List<string>()
    {
     "foo st. 2","foo bld 1","foo st 22","foo st 1"
    };
    List<string> deleted=new List<string>();
    List<string> notdeleted=new List<string>();
    using(SqlConnection cn=new SqlConnection("connStr"))
     {
      using(SqlCommand cmd=new SqlCommand())
      {
        cmd.CommandText="DELETE from TableName Where Address=@address";
        cmd.Connection=cn;
        cmd.Parameters.Add("@address",SqlDbType.VarChar,50);
        cn.Open();
        for(String address in addresses)
         {
           cmd.Parameters["@address"].Value=address;
           int result=cmd.ExecuteNonQuery();
           if(result!=-1)
            {
              //deleted
              deleted.Add(address);
            }
          else
            {
             //not deleted
             notdeleted.Add(address);
            }
         }
        cn.Close();
       }
     }
