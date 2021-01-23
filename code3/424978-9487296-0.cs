    using System;
    using System.Data.SqlClient;
    
    class Program
    {
      static void Main(string[] args)
      {
        byte[] bytes = new byte[]{0,1,2,3,4,65,66,4,3,2,1,0};
    
        using(var con = new SqlConnection(@"<your connection string here>"))
        {
          con.Open();
    
          var cmd = con.CreateCommand();
            
          // Insert binary data into varchar
          cmd.CommandText = "insert into BinTest (BinData) values (cast(@BinData as varbinary))"; 
          cmd.Parameters.AddWithValue("BinData", bytes);
          cmd.ExecuteNonQuery();
    
          // Read binary data from varchar
          cmd.Parameters.Clear();
          cmd.CommandText = "select cast(BinData as varbinary) from BinTest";
          using (var rdr = cmd.ExecuteReader())
          {
            while (rdr.Read())
            {
              if (!rdr.IsDBNull(0))
              {
                var data = rdr.GetSqlBinary(0);
                Console.WriteLine(BitConverter.ToString(data.Value));
              }
            }
          }
        }
      }
    }
