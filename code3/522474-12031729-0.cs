     //string categoriesJoined = string.Join(",", cats);
     using (var conn = new SqlConnection())
     {
          conn.Open();
          //make this a union all
          return _categories = conn.Query<Category>("select Id, ParentId, Name from [Meshplex].[dbo].Category where Id IN (@joined)", new { joined = cats}).ToList();
      }
