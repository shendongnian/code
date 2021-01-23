     var recipientsInDBIds = new Hashset(RecipientsInDB.Select(u => u.ID));
     foreach (var item in RecipientsInFile)
        {
            if (!recipientsInDBIds.Contains(item.ID ))
            {
               Console.WriteLine(GetInsertSql(item));
            }
        }
        Console.ReadLine();
