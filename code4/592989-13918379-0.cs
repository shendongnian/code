     using (IDbConnection cn = manager.GetConnection)
     using (var reader = manager.GetReader())
     {
         cn.Open();
    
         while (reader.Read())
             list.Add(factory.CreateTFromReader(reader));
     }
