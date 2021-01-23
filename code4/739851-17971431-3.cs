       if (currentWork != null)
                 {
                     Console.WriteLine("Access is not null");
                     myEntity.ExecuteStoredCommand("UPDATE works SET WordCount = WordCount + 5 WHERE RID = @rid", new MySqlParameter("@rid", MySqlDbType.Int32){Value = 208)
                     Console.WriteLine("Count changed");
                 }
        var record = myEntity.works.FirstOrDefault(xXx => xXx.RID == 208);
        if(record != null)
            Console.WriteLine("Current Count:" + record .WordCount);
