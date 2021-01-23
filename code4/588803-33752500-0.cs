        List<String> resultString = new List<string>(); 
     var result = await db.QueryAsync<DistinctGroupNamesResult>("SELECT * FROM SOs_Locations");
        
           foreach (string item in result.Select(x=> x.GroupName).Distinct())
                    {
                        resultString.Add(item);
                    }
          return resultString;
