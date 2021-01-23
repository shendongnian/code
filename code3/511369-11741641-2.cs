    string qry = "select * From ImagesStore";
    
    using(SqlConnection Cn=new SqlConnect(CnStr))
    {
      using(SqlCommand SqlCom = new SqlCommand(qry, CN))
      {
        Cn.Open();
        using(SqlDataReader dr=SqlCom.ExecuteReader())
        {
          while(dr.Read())
          {
              string path="x:\\folder\\" + dr[0] + ".png";
              byte []bytes=dr.GetBytes(1);
              System.IO.File.WriteAllBytes(path,bytes);
           }
        }
      }
    }
   
 
